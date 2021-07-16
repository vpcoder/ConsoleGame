using Engine.Data;
using System.Windows.Forms;
using View = Engine.Data.View;

namespace Engine.Services
{

    /// <summary>
    /// Сервис управления персонажем
    /// </summary>
    public class ControllService
    {

        private World world;
        private Player player;
        private View view;
        private Map map;
        private IInventory inventory;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса управления, принемает мир, в рамках которого мы управляем игроком
        /// </summary>
        public ControllService(World world)
        {
            this.world = world;
            this.map = world.Map;
            this.player = world.Player;
            this.inventory = player.Inventory;
            this.view = world.View;
        }

        /// <summary>
        /// Метод одной итерации управления персонажем
        /// </summary>
        /// <param name="key">Что сделал игрок</param>
        public void Controll(KeyEventArgs e)
        {
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
                player.PosX += vector.Y;

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

    }

}
