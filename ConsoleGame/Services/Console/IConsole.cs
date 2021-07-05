using System.Drawing;

namespace Engine
{

    ///<summary>
    /// Интерфейс консоли для игры
    ///</summary>
    public interface IConsole
    {

        // - Читаем клавиши, которые нажимает игрок
        int ReadKey();

        // - Рисовать символ/символы определённого цвета в определённом месте
        void Draw(string text, Color foreColor, int x, int y);
        void Draw(string text, Color foreColor, Color backgroundColor, int x, int y);

    }

}
