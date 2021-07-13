using System.Collections.Generic;
using System.Drawing;
using System;

namespace Engine.Services
{

    public class ImageFactory
    {

        private static Lazy<ImageFactory> instance = new Lazy<ImageFactory>(() => new ImageFactory(), true);

        private ImageFactory() { }

        public static ImageFactory Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private IDictionary<string, Image> data = new Dictionary<string, Image>();

        public Image Get(string id)
        {
            Image tmpImage = null;
            if(data.TryGetValue(id, out tmpImage))
            {
                return tmpImage;
            }
#if DEBUG
            var path = "../../images/" + id + ".png";
#else
            var path = "images/" + id + ".png";
#endif

            if (!System.IO.File.Exists(path))
            {
                return null;
            }

            tmpImage = Image.FromFile(path);
            data.Add(id, tmpImage);
            return tmpImage;
        }

    }

}
