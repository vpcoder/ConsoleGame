
using System;
using System.Collections.Generic;

namespace Engine.Data
{

    /// <summary>
    /// Объект карты
    /// </summary>
    public class Map
    {

        private const int LAYOUT_COUNT = 7;

        public int LayoutCount { get; } = LAYOUT_COUNT;

        public int CenterLayout { get; } = (LAYOUT_COUNT / 2) + 1;

        /// <summary>
        /// Стартовая позиция персонажа на карте по X
        /// </summary>
        public int PlayerStartPosX { get; set; }
        /// <summary>
        /// Стартовая позиция персонажа на карте по Y
        /// </summary>
        public int PlayerStartPosY { get; set; }

        /// <summary>
        /// Размер карты по X
        /// </summary>
        public int SizeX { get; private set; }
        /// <summary>
        /// Размер карты по Y
        /// </summary>
        public int SizeY { get; private set; }

        /// <summary>
        /// Имя карты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Матрица карты - то что лежит "снизу"
        /// </summary>
        private ISprite[][,] Matrix;

        /// <summary>
        /// Инициализация карты (конструкторв)
        /// </summary>
        /// <param name="w">Размер карты по X (ширина)</param>
        /// <param name="h">Размер карты по Y (высота)</param>
        public Map(int w, int h)
        {
            Resize(w, h);
        }

        /// <summary>
        /// Инициализация карты (конструкторв)
        /// </summary>
        public Map()
        {
            SizeX = 0;
            SizeY = 0;
        }

        /// <summary>
        /// Изменяет размер карты
        /// </summary>
        /// <param name="w">Размер карты по X (ширина)</param>
        /// <param name="h">Размер карты по Y (высота)</param>
        public void Resize(int w, int h)
        {
            var tmpMatrix = this.Matrix;

            // Создаём новый массив
            this.Matrix = new Sprite[LayoutCount][,];
            for (int layout = 0; layout < LayoutCount; layout++)
                this.Matrix[layout] = new Sprite[w, h];

            // Если ранее карта уже существовала, пытаемся перенести всё из неё на новую карту
            if (tmpMatrix != null && this.SizeX > 0 && this.SizeY > 0)
            {
                int safeX = Math.Min(this.SizeX, w);
                int safeY = Math.Min(this.SizeY, h);
                for (int layout = 0; layout < LayoutCount; layout++)
                {
                    for (int y = 0; y < safeY; y++)
                    {
                        for (int x = 0; x < safeX; x++)
                        {
                            this.Matrix[layout][x, y] = tmpMatrix[layout][x, y];
                        }
                    }
                }
            }

            this.SizeX = w;
            this.SizeY = h;
        }

        /// <summary>
        /// Пересоздаёт карту, по подобию той что дали в аргументе
        /// </summary>
        /// <param name="map">Карта, которую нужно перенести в текущую</param>
        public void ResizeFrom(Map map)
        {
            this.Matrix = map.Matrix;
            this.SizeX  = map.SizeX;
            this.SizeY  = map.SizeY;
        }

        /// <summary>
        /// Перебирает все объекты со всех слоёв
        /// </summary>
        public IEnumerable<ISprite> GetAll()
        {
            ICollection<ISprite> data = new HashSet<ISprite>();
            for(int layout = 0; layout < LayoutCount; layout++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    for (int x = 0; x < SizeX; x++)
                    {
                        var item = Matrix[layout][x, y];
                        if (item == null)
                            continue;
                        yield return item;
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает объект со слоя layout на позиции x, y
        /// </summary>
        /// <param name="layout">слой, с которого получаем объект</param>
        /// <param name="x">Позиция объекта по x</param>
        /// <param name="y">Позиция объекта по y</param>
        /// <returns>Объект с карты</returns>
        public ISprite Get(int layout, int x, int y)
        {
            if (!isIntersection(x, y))
                return null;
            return Matrix[layout][x, y];
        }

        /// <summary>
        /// Устанавливает объект на слое layout на позиции x, y
        /// </summary>
        /// <param name="sprite">устанавливаемый объект</param>
        /// <param name="layout">слой</param>
        /// <param name="x">Позиция объекта по x</param>
        /// <param name="y">Позиция объекта по y</param>
        public void Set(ISprite sprite, int layout, int x, int y)
        {
            if (!isIntersection(x, y))
                return;
            this.Matrix[layout][x, y] = sprite;
        }

        /// <summary>
        /// Можно ли ходить по указанной ячейке, с учётом всех слоёв ниже среднего
        /// </summary>
        /// <param name="x">Положение точки по X</param>
        /// <param name="y">Положение точки по Y</param>
        /// <returns>Можно ли ходить по указанной точке, с учётом всех слоёв ниже среднего</returns>
        public bool IsWalkable(int x, int y)
        {
            if(!isIntersection(x,y))
                return false;
            for(int layout = 0; layout < CenterLayout; layout++)
            {
                var sprite = Matrix[layout][x, y];
                if(sprite == null)
                {
                    continue;
                }
                var obj = sprite as IObject;
                if(obj == null)
                {
                    continue;
                }
                if(obj.Walkable)
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        private bool isIntersection(int x, int y)
        {
            return !(x < 0 || x >= SizeX || y < 0 || y >= SizeY);
        }

    }

}
