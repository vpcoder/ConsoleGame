using Engine.AStarSharp;
using Engine.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Engine.Services
{

    /// <summary>
    /// Сервис отрисовки нашего мира, и его частей
    /// </summary>
    public class DrawService
    {

        private IConsole console;
        private World world;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса отрисовки
        /// </summary>
        public DrawService(World world, IConsole console)
        {
            this.world = world;
            this.console = console;
        }

        /// <summary>
        /// Отрисовывает мир - медленный и неоптимальный метод, не подходит для постоянной перерисовки,
        /// но подходит для первичного отображения карты
        /// </summary>
        /// <param name="world">Мир, который нужно отрисовать</param>
        public void Draw()
        {
            var map = world.Map;
            for (var y = 0; y < world.Map.SizeY; y++)
            {
                for (var x = 0; x < world.Map.SizeX; x++)
                {
                    if (world.Player.PosX == x && world.Player.PosY == y)
                    {
                        DrawPlayer(x, y);
                    }
                    else
                    {
                        DrawObject(GetVisibleObject(x, y), x, y);
                    }
                }
            }
            DrawInventory();
            DrawPlayerCharacteristic();

            console.Draw("input:", Color.White, 0, world.Map.SizeY + 1);
            EndDraw();
        }

        private SpriteChar GetVisibleObject(int x, int y)
        {
            var map = world.Map;
            return map.Frontground(x, y) ?? map.Background(x, y); // Сначала смотрим на то что на переднем плане, а потом на то что на заднем плане
        }

        /// <summary>
        /// Метод перерисовки последнего местоположения персонажа
        /// </summary>
        public void Redraw(int prevPosX, int prevPosY)
        {
            DrawObject(GetVisibleObject(prevPosX, prevPosY), prevPosX, prevPosY);            
            DrawPlayer(world.Player.PosX, world.Player.PosY);
            DrawInventory();
            DrawPlayerCharacteristic();
            EndDraw();
        }

        public void DrawPath(List<Node> path)
        {
            if (path == null)
            {
                EndDraw();
                return;
            }
            foreach(var node in path)
            {
                console.Draw("▒", Color.Green, node.Position.X, node.Position.Y);               
            }
            EndDraw();
        }

        private void EndDraw()
        {
            console.Draw("", Color.White, 7, world.Map.SizeY + 1);
        }

        /// <summary>
        /// Рисует персонажа в указанной позиции
        /// </summary>
        /// <param name="x">Располоэение персонажа по X</param>
        /// <param name="y">Располоэение персонажа по Y</param>
        private void DrawPlayer(int posX, int posY)
        {
            console.Draw(Convert.ToString(world.Player.Symbol), world.Player.Color, posX, posY);          
        }

        /// <summary>
        /// Рисует объект в указанной позиции
        /// </summary>
        /// <param name="x">Располоэение объекта по X</param>
        /// <param name="y">Располоэение объекта по Y</param>
        /// <param name="obj">Рисуемый объект</param>
        private void DrawObject(SpriteChar obj, int posX, int posY)
        {
            if (obj == null)
            {
                console.Draw(" ", Color.Black, posX, posY);             
                return;
            }
            console.Draw(Convert.ToString(obj.Symbol), obj.Color, posX, posY);          
        }

        /// <summary>
        /// Рисует инвентарь в игре
        /// </summary>
        private void DrawInventory()
        {
            var inventory = world.Player.Inventory;
            var index = -1;
            foreach (Item item in inventory.Items)
            {
                index++;
                if (inventory.SelectedIndex == index)
                {                  
                    console.Draw(GetNormalizedText(item?.Title), Color.White, world.Map.SizeX + 2, 6);
                   
                    console.Draw(GetNormalizedText(GenerateItemDescription(item)), Color.White, world.Map.SizeX + 2, 7);

                    //System.Console.BackgroundColor = System.ConsoleColor.DarkGreen;
                }
                else
                {
                    //System.Console.BackgroundColor = System.ConsoleColor.Black;
                }
                DrawObject(item, world.Map.SizeX + 2 + index % 5, 1 + index / 5);
            }
        }

        private void DrawPlayerCharacteristic()
        {          
            var barLength = world.Player.HP / (world.Player.MaxHP / 10);
            var emptyLength = 10 - barLength;
            var progress = (string.Empty.PadRight(barLength, '█')).PadRight(10, '▒') + $" {world.Player.HP}/{world.Player.MaxHP}";

            console.Draw(progress, Color.DarkRed, world.Map.SizeX + 2, 9);

            var info = $"АТК: {world.Player.Damage} ЗАЩ: {world.Player.Defence}   ";
            console.Draw(info, Color.White, world.Map.SizeX + 2, 11);           
        }


        private string GenerateItemDescription(Item item)
        {
            if (item == null)
                return null;
            StringBuilder builder = new StringBuilder();
            builder.Append(item.Description);

            if (item is Armor)
            {
                var armor = (Armor)item;
                builder.Append(" +" + armor.Defence + "ед. защиты");
            }
            if (item is Weapon)
            {
                var weapon = (Weapon)item;
                builder.Append(" +" + weapon.Damage + "ед. урона");
            }
            if (item is UsedItem)
            {
                var usedItem = (UsedItem)item;
                builder.Append(" <используется>");
            }

            if (item.MaxStackSize != 1)
                builder.Append(" " + item.StackSize + "/" + item.MaxStackSize + " шт.");

            return builder.ToString();
        }

        private string GetNormalizedText(string text)
        {
            if (text == null)
            {
                return string.Empty.PadRight(70, ' ');
            }
            return text.PadRight(70, ' ');
        }

    }

}
