using Engine.Data;
using System.Drawing;

namespace Engine
{

    ///<summary>
    /// Интерфейс консоли для игры
    ///</summary>
    public interface IConsole
    {

        // Рисует спрайт
        void Draw(Sprite sprite, int x, int y);
        // Рисует спрайт
        void Draw(Sprite sprite, Color backgroundColor, int x, int y);

        // Рисует текст, если задан backgroundColor, рисует ещё и подложку текста
        void Draw(string text, Color foreColor, Color backgroundColor, int x, int y);

        void Draw(string text, Color foreColor, int x, int y);

    }

}
