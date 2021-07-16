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
            var keyCode = e.KeyCode;
            int playerPosX = player.PosX;
            int playerPosY = player.PosY;

            switch (keyCode)
            {
                case Keys.W:
                    if(player.Direction != Direction.Up)
                    {
                        player.Direction = Direction.Up;
                        break;
                    }
                    if(IsWalkable(playerPosX, playerPosY - 1))
                    {
                        player.PosY -= 1; // Двигаем персонажа

                        var delta = player.PosY - view.PosY;
                        if(delta < view.SizeY / 2 && view.PosY > 0)
                            view.PosY -= 1; // Двигаем рамку
                    }
                    break;
                case Keys.A:
                    if (player.Direction != Direction.Left)
                    {
                        player.Direction = Direction.Left;
                        break;
                    }
                    if (IsWalkable(playerPosX - 1, playerPosY))
                    {
                        player.PosX -= 1;

                        var delta = player.PosX - view.PosX;
                        if (delta < view.SizeX / 2 && view.PosX > 0)
                            view.PosX -= 1; // Двигаем рамку
                    }
                    break;
                case Keys.S:
                    if (player.Direction != Direction.Down)
                    {
                        player.Direction = Direction.Down;
                        break;
                    }
                    if (IsWalkable(playerPosX, playerPosY + 1))
                    {
                        player.PosY += 1;

                        var delta = player.PosY - view.PosY;
                        if (delta > view.SizeY / 2 && view.PosY < map.SizeY - view.SizeY)
                            view.PosY += 1; // Двигаем рамку
                    }
                    break;
                case Keys.D:
                    if (player.Direction != Direction.Right)
                    {
                        player.Direction = Direction.Right;
                        break;
                    }
                    if (IsWalkable(playerPosX + 1, playerPosY))
                    {
                        player.PosX += 1;

                        var delta = player.PosX - view.PosX;
                        if (delta > view.SizeX / 2 && view.PosX < map.SizeX - view.SizeX)
                            view.PosX += 1; // Двигаем рамку
                    }
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
                    var selectedItem = inventory.Selected;
                    if(selectedItem == null)
                    {
                        break;
                    }

                    if (selectedItem is UsedItem) // Используемые предметы?
                    {
                        var usedItem = selectedItem as UsedItem;
                        usedItem.Use(world);
                        if (selectedItem.StackSize != 1)
                        {
                            selectedItem.StackSize -= 1;
                        }
                        else
                        {
                            inventory.Selected = null;
                        }
                        break;
                    }
                    if (selectedItem is Armor) // Броня?
                    {
                        var armor = selectedItem as Armor;
                        var tmpArmor = player.Armor;
                        player.Armor = armor;
                        inventory.Selected = tmpArmor;
                        break;
                    }
                    if (selectedItem is Weapon) // Оружие?
                    {
                        var weapon = selectedItem as Weapon;
                        var tmpWeapon = player.Weapon;
                        player.Weapon = weapon;
                        inventory.Selected = tmpWeapon;
                        break;
                    }
                    // Непонятно что за предмет, возможно ошибка в коде?
                    break;
            }
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
