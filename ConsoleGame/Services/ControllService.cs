using Engine.Data;
using Engine.Data.Impls;
using System;

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
        public void Controll(ConsoleKeyInfo key)
        {
            int playerPosX = world.Player.PosX;
            int playerPosY = world.Player.PosY;

            switch(key.Key)
            {
                case ConsoleKey.W:
                    if(canWalkToXY(playerPosX, playerPosY - 1))
                    {
                        world.Player.PosY -= 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (canWalkToXY(playerPosX - 1, playerPosY))
                    {
                        world.Player.PosX -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (canWalkToXY(playerPosX, playerPosY + 1))
                    {
                        world.Player.PosY += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (canWalkToXY(playerPosX + 1, playerPosY))
                    {
                        world.Player.PosX += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    world.Player.Inventory.SelectedIndex--;
                    if (world.Player.Inventory.SelectedIndex < 0)
                        world.Player.Inventory.SelectedIndex = world.Player.Inventory.Items.Length - 1;
                    break;
                case ConsoleKey.RightArrow:
                    world.Player.Inventory.SelectedIndex++;
                    if (world.Player.Inventory.SelectedIndex >= world.Player.Inventory.Items.Length)
                        world.Player.Inventory.SelectedIndex = 0;
                    break;
                case ConsoleKey.UpArrow:
                    world.Player.Inventory.SelectedIndex -= 5;
                    if (world.Player.Inventory.SelectedIndex < 0)
                        world.Player.Inventory.SelectedIndex += world.Player.Inventory.Items.Length;
                    break;
                case ConsoleKey.DownArrow:
                    world.Player.Inventory.SelectedIndex += 5;
                    if (world.Player.Inventory.SelectedIndex >= world.Player.Inventory.Items.Length)
                        world.Player.Inventory.SelectedIndex -= world.Player.Inventory.Items.Length;
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
            var charItem = world.Map.Matrix[x, y];
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
