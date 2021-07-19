using Engine.Console;
using Engine.Data;
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
        private View view;

        /// <summary>
        /// Конструктор, срабатывает при создании экземпляра сервиса отрисовки
        /// </summary>
        public DrawService(World world, IConsole console)
        {
            this.world = world;
            this.view = world.View;
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
            for (int layout = 0; layout < map.LayoutCount; layout++) // Перебираем слои карты
            {
                for (var y = 0; y < console.ViewHeight; y++) // Перебираем объекты во фрейме
                {
                    for (var x = 0; x < console.ViewWidth; x++) // Перебираем объекты во фрейме
                    {
                        var worldPos = view.GetPointInWorld(x, y); // получаем координаты в мире
                        var sprite = map.Get(layout, worldPos); // Получаем объект в указанной точке карты на указанном слое
                        DrawTile(sprite, x, y, Color.Empty); // Рисуем объект в области видимости на указанном слое
                    }
                }

                if(layout == map.CenterLayout) // Средний слой
                {
                    DrawBullets();
                    DrawCharacter(world.Player);
                    DrawNPCs();
                }
            }
            DrawInventory();
            DrawPlayerCharacteristic();
        }

        private void DrawBullets()
        {
            foreach (var bullet in world.Bullets)
                DrawBullet(bullet);
        }

        private void DrawBullet(IBullet bullet)
        {
            if (!world.View.IsPointInView(bullet.ToPos()))
                return;
            var sprite = ImageFactory.Instance.Get(bullet.ID, bullet.Direction);
            var pos = view.GetPointInView(bullet.ToPos());
            console.Draw(sprite, pos.X, pos.Y);
        }

        private void DrawNPCs()
        {
            foreach (var npc in world.NPCs)
                DrawCharacter(npc);
        }

        private void DrawCharacter(ICharacter character)
        {
            if (!world.View.IsPointInView(character.ToPos()))
                return;
            var sprite = ImageFactory.Instance.Get(character.ID, character.Direction);
            var pos = view.GetPointInView(character.ToPos());
            console.Draw(sprite, pos.X, pos.Y);
        }

        /// <summary>
        /// Рисует объект в указанной позиции
        /// </summary>
        /// <param name="x">Располоэение объекта по X</param>
        /// <param name="y">Располоэение объекта по Y</param>
        /// <param name="obj">Рисуемый объект</param>
        private void DrawTile(ISprite obj, int posX, int posY, Color backgroundClolor)
        {
            var image = obj == null ? null : ImageFactory.Instance.Get(obj.ID);
            console.Draw(image, backgroundClolor, posX, posY);
        }


        private static readonly Color inventoryItemBackground = Color.FromArgb(64, 0, 255, 0);
        private static readonly Color inventoryTextBackground = Color.FromArgb(64, 0, 0, 0);

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
                    console.Draw(item?.Title, Color.White, inventoryTextBackground, world.View.SizeX - 12, 6);
                    console.Draw(GenerateItemDescription(item), Color.White, inventoryTextBackground, world.View.SizeX - 12, 7);
                    DrawTile(item, world.View.SizeX - 6 + index % 5, 1 + index / 5, inventoryItemBackground);
                }
                else
                {
                    DrawTile(item, world.View.SizeX - 6 + index % 5, 1 + index / 5, Color.Empty);
                }
            }
        }

        private void DrawPlayerCharacteristic()
        {
            var player = world.Player;
            var damage = CalculationService.Instance.GetDamage(player);
            var defence = CalculationService.Instance.GetDefence(player);
            var text = $"Здоровье: {player.Characteristics.Health}/{player.Characteristics.MaxHealth}\nАТК: {damage} ЗАЩ: {defence}";
            console.Draw(text, Color.DarkRed, world.View.SizeX - 6, world.View.SizeY - 2);
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

    }

}
