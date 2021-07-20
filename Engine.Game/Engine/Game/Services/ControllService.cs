using Engine.Data;
using System;
using System.Windows.Forms;
using View = Engine.Data.View;

namespace Engine.Services
{

    /// <summary>
    /// Сервис управления персонажем
    /// </summary>
    public class ControllService
    {

        private BattleService battleService;
        private World world;
        private Player player;
        private View view;
        private Map map;
        private IInventory inventory;

        private BattleStrategyType playerStrategy;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса управления, принемает мир, в рамках которого мы управляем игроком
        /// </summary>
        public ControllService(World world, BattleService battleService)
        {
            this.world = world;
            this.battleService = battleService;
            this.map = world.Map;
            this.player = world.Player;
            this.inventory = player.Inventory;
            this.view = world.View;
            this.playerStrategy = CurrentStrategy;
        }

        private BattleStrategyType CurrentStrategy
        {
            get
            {
                if (player.Weapon == null)
                    return BattleStrategyType.Near;

                if (player.Weapon is IWeaponRanged)
                    return BattleStrategyType.Far;

                return BattleStrategyType.Near;
            }
        }

        /// <summary>
        /// Метод одной итерации управления персонажем
        /// </summary>
        /// <param name="key">Что сделал игрок</param>
        public void Controll(KeyEventArgs e)
        {
            if (player.Characteristics.IsDead)
                return;

            switch (e.KeyCode)
            {
                case Keys.W:
                    DoMove(Direction.Up);
                    break;
                case Keys.A:
                    DoMove(Direction.Left);
                    break;
                case Keys.S:
                    DoMove(Direction.Down);
                    break;
                case Keys.D:
                    DoMove(Direction.Right);
                    break;

                case Keys.Left:
                    inventory.SelectedIndex--;
                    if (inventory.SelectedIndex < 0)
                        inventory.SelectedIndex = 0;
                    break;
                case Keys.Right:
                    inventory.SelectedIndex++;
                    if (inventory.SelectedIndex >= inventory.InventoryMaxSize)
                        inventory.SelectedIndex = inventory.InventoryMaxSize - 1;
                    break;
                case Keys.Up:
                    if (inventory.SelectedIndex - 5 >= 0)
                        inventory.SelectedIndex -= 5;
                    break;
                case Keys.Down:
                    if (inventory.SelectedIndex + 5 < inventory.InventoryMaxSize)
                        inventory.SelectedIndex += 5;
                    break;

                case Keys.E:
                    DoUseItem(inventory.Selected);
                    break;

                case Keys.Space:
                    DoAttack();
                    break;
            }
        }

        private void DoMove(Direction direction)
        {
            var vector = direction.ToVector();

            var playerPosX = player.PosX + vector.X;
            var playerPosY = player.PosY + vector.Y;

            if (player.Direction != direction)
            {
                player.Direction = direction;
                return;
            }

            if (IsWalkable(playerPosX, playerPosY))
            {
                // Двигаем персонажа
                player.PosX += vector.X;
                player.PosY += vector.Y;

                // Двигаем рамку
                var deltaX = player.PosX - view.PosX;
                var deltaY = player.PosY - view.PosY;

                if (vector.X < 0 && deltaX < view.SizeX / 2 && view.PosX > 0)
                {
                    view.PosX -= 1;
                    return;
                }

                if (vector.X > 0 && deltaX > view.SizeX / 2 && view.PosX < map.SizeX - view.SizeX) { 
                    view.PosX += 1;
                    return;
                }

                if (vector.Y < 0 && deltaY > view.SizeY / 2 && view.PosY > 0) { 
                    view.PosY -= 1;
                    return;
                }

                if (vector.Y > 0 && deltaY > view.SizeY / 2 && view.PosY < map.SizeY - view.SizeY) { 
                    view.PosY += 1;
                    return;
                }
            }
        }

        private void DoUseItem(IItem selectedItem)
        {
            if (selectedItem == null)
                return;

            if (selectedItem is IUsedItem) // Используемые предметы?
            {
                var usedItem = selectedItem as IUsedItem;
                usedItem.Use(world);
                if (selectedItem.StackSize != 1)
                {
                    selectedItem.StackSize -= 1;
                }
                else
                {
                    inventory.Selected = null;
                }
                return;
            }
            if (selectedItem is IArmor) // Броня?
            {
                var armor = selectedItem as IArmor;
                var tmpArmor = player.Armor;
                player.Armor = armor;
                inventory.Selected = tmpArmor;
                return;
            }
            if (selectedItem is IWeapon) // Оружие?
            {
                var weapon = selectedItem as IWeapon;
                var tmpWeapon = player.Weapon;
                player.Weapon = weapon;
                inventory.Selected = tmpWeapon;
                playerStrategy = CurrentStrategy;
                return;
            }
            // Непонятно что за предмет, возможно ошибка в коде?
        }

        private bool IsWalkable(int posX, int posY)
        {
            if (!map.IsWalkable(posX, posY))
                return false;

            foreach (var npc in world.NPCs)
                if (npc.PosX == posX && npc.PosY == posY)
                    return false;

            return true;
        }

        private void DoAttack()
        {
            var timestamp = TimeService.Instance.Time;

            if ((player.Weapon != null && timestamp - player.LastUseWeaponTime < player.Weapon.UseInterval)
                || (player.Weapon == null && timestamp - player.LastUseWeaponTime < player.HandsInterval)) // Оружие не готово к использованию, перезаряжаемся...
                return;

            player.LastUseWeaponTime = timestamp;


            switch (playerStrategy)
            {
                case BattleStrategyType.Near:
                    var enemy = GetCharacterInDirection(player.ToPos(), player.Direction);
                    if (enemy == null)
                        return;

                    battleService.DoMeleeAttack(player, enemy);
                    break;
                case BattleStrategyType.Far:

                    var weapon = (IWeaponRanged)player.Weapon;
                    var bulletSet = inventory.GetFirstByType(weapon.Bullet); // Извлекаем первый попавшийся набор подходящих нашему оружию в руках снарядов из инвентаря

                    if (bulletSet == null) // Кончились все снаряды в инвентаре
                        return;

                    bulletSet.StackSize--; // Расходуем снаряд
                    if (bulletSet.StackSize == 0) // Полностью израсходовали пачку?
                    {
                        inventory.RemoveItem(bulletSet); // Удаляем пустую пачку из инвентаря
                    }

                    var bullet = (IBullet)Activator.CreateInstance(bulletSet.GetType());
                    battleService.DoRangedAttack(player, weapon, bullet);
                    break;
            }
        }

        private ICharacter GetCharacterInDirection(Vector2 pos, Direction direction)
        {
            var selPos = pos + direction.ToVector(); // Позиция рассчитанная от текущей позиции + клетка в сторону направления взгляда
            foreach(var character in world.NPCs)
            {
                if (character.Characteristics.IsDead)
                    continue;
                if (character.ToPos() == selPos)
                    return character;
            }
            return null;
        }
        
    }

}
