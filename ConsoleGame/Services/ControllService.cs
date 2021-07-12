using Engine.Data;
using Engine.Data.Impls;
using System;
using System.Windows.Forms;

namespace Engine.Services
{

    /// <summary>
    /// Сервис управления персонажем
    /// </summary>
    public class ControllService
    {

        private World world;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса управления, принемает мир, в рамках которого мы управляем игроком
        /// </summary>
        public ControllService(World world)
        {
            this.world = world;
        }

        /// <summary>
        /// Метод одной итерации управления персонажем
        /// </summary>
        /// <param name="key">Что сделал игрок</param>
        public void Controll(KeyEventArgs e)
        {
            var keyCode = e.KeyCode;
            int playerPosX = world.Player.PosX;
            int playerPosY = world.Player.PosY;
            switch (keyCode)
            {
                case Keys.W:
                    if(canWalkToXY(playerPosX, playerPosY - 1))
                    {
                        world.Player.PosY -= 1;
                    }
                    break;
                case Keys.A:
                    if (canWalkToXY(playerPosX - 1, playerPosY))
                    {
                        world.Player.PosX -= 1;
                    }
                    break;
                case Keys.S:
                    if (canWalkToXY(playerPosX, playerPosY + 1))
                    {
                        world.Player.PosY += 1;
                    }
                    break;
                case Keys.D:
                    if (canWalkToXY(playerPosX + 1, playerPosY))
                    {
                        world.Player.PosX += 1;
                    }
                    break;

                case Keys.Left:
                    world.Player.Inventory.SelectedIndex--;
                    if (world.Player.Inventory.SelectedIndex < 0)
                        world.Player.Inventory.SelectedIndex = world.Player.Inventory.Items.Length - 1;
                    break;
                case Keys.Right:
                    world.Player.Inventory.SelectedIndex++;
                    if (world.Player.Inventory.SelectedIndex >= world.Player.Inventory.Items.Length)
                        world.Player.Inventory.SelectedIndex = 0;
                    break;
                case Keys.Up:
                    world.Player.Inventory.SelectedIndex -= 5;
                    if (world.Player.Inventory.SelectedIndex < 0)
                        world.Player.Inventory.SelectedIndex += world.Player.Inventory.Items.Length;
                    break;
                case Keys.Down:
                    world.Player.Inventory.SelectedIndex += 5;
                    if (world.Player.Inventory.SelectedIndex >= world.Player.Inventory.Items.Length)
                        world.Player.Inventory.SelectedIndex -= world.Player.Inventory.Items.Length;
                    break;

                case Keys.E:
                    var selectedItem = world.Player.Inventory.Selected;
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
                            world.Player.Inventory.Selected = null;
                        }
                        break;
                    }
                    if (selectedItem is Armor) // Броня?
                    {
                        var armor = selectedItem as Armor;
                        var tmpArmor = world.Player.Armor;
                        world.Player.Armor = armor;
                        world.Player.Inventory.Selected = tmpArmor;
                        break;
                    }
                    if (selectedItem is Weapon) // Оружие?
                    {
                        var weapon = selectedItem as Weapon;
                        var tmpWeapon = world.Player.Weapon;
                        world.Player.Weapon = weapon;
                        world.Player.Inventory.Selected = tmpWeapon;
                        break;
                    }
                    // Непонятно что за предмет, возможно ошибка в коде?
                    break;
            }
        }

        /// <summary>
        /// Определяет - можно ли ходить в точку x,y на карте или нет?
        /// </summary>
        /// <param name="x">Точка на карте по X</param>
        /// <param name="y">Точка на карте по Y</param>
        /// <param name="world">Мир, в котром выполняется расчёт</param>
        /// <returns></returns>
        private bool canWalkToXY(int x, int y)
        {
            if (x < 0 || y < 0 || x >= world.Map.SizeX || y >= world.Map.SizeY)
            {
                return false;
            }
            var charItem = world.Map.Matrix0[x, y];
            if (charItem == null)
            {
                return true;
            }
            var objItem = charItem as Engine.Data.Object; // Пробуем скастовать чар к объекту на карте
            if (objItem != null)
            {
                return objItem.Walkable;
            }
            return false; // не знаем что за объект, на всякий случай, ходить по нему нельзя
        }

    }

}
