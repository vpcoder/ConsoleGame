using System.Collections.Generic;
using System.Drawing;
using System;
using Engine.Properties;
using Engine.Data;
using System.Text;

namespace Engine.Services
{

    /// <summary>
    /// Фабрика картинок с кешем
    /// </summary>
    public class ImageFactory
    {

        #region Singleton

        private static Lazy<ImageFactory> instance = new Lazy<ImageFactory>(() => new ImageFactory(), true);

        public static ImageFactory Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private ImageFactory()
        {
            foreach(Direction direction in Enum.GetValues(typeof(Direction)))
                directionalData.Add(direction, new Dictionary<string, Image>());
        }

        #endregion

        /// <summary>
        /// Настройки
        /// </summary>
        private static Settings settings = Settings.Default;

        /// <summary>
        /// Общие спрайты
        /// </summary>
        private IDictionary<string, Image> data = new Dictionary<string, Image>();

        /// <summary>
        /// Направленные спрайты
        /// </summary>
        private IDictionary<Direction,IDictionary<string,Image>> directionalData = new Dictionary<Direction, IDictionary<string, Image>>();

        /// <summary>
        /// Билдер для идентификаторов картинок
        /// </summary>
        private StringBuilder builder = new StringBuilder();

        public Image Get(string id)
        {
            Image tmpImage = null;
            if(data.TryGetValue(id, out tmpImage))
            {
                return tmpImage;
            }

            var path = GetPath(id);
            if (!System.IO.File.Exists(path))
            {
                return null;
            }

            tmpImage = Image.FromFile(path);
            data.Add(id, tmpImage);
            return tmpImage;
        }

        private string GetPath(string id)
        {
            builder.Clear();
#if DEBUG
            builder.Append(settings.ImagesPath);
#else
            builder.Append("images/");
#endif
            builder.Append(id);
            builder.Append(".png");
            return builder.ToString();
        }

        public Image Get(string id, Direction direction)
        {
            Image tmpImage = null;
            if (directionalData[direction].TryGetValue(id, out tmpImage))
            {
                return tmpImage;
            }

            var path = GetPath(id, direction);
            if (!System.IO.File.Exists(path))
            {
                return null;
            }
            tmpImage = Image.FromFile(path);
            directionalData[direction].Add(id, tmpImage);
            return tmpImage;
        }

        private string GetPath(string id, Direction direction)
        {
            builder.Clear();
#if DEBUG
            builder.Append(settings.ImagesPath);
#else
            builder.Append("images/");
#endif
            builder.Append(id);
            builder.Append("_");
            builder.Append(direction.ToString());
            builder.Append(".png");
            return builder.ToString();
        }

    }

}
