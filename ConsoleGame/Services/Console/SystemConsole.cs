using System;
using System.Drawing;
using System.Text;

namespace Engine
{

    public class SystemConsole : IConsole
    {

        public SystemConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding  = Encoding.UTF8;
        }

        private ConsoleColor GetConsoleColorFromTrueColor(Color foreColor)
        {
            return ConsoleColor.White;
        }

        public void Draw(string text, Color foreColor, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = GetConsoleColorFromTrueColor(foreColor);
            Console.Write(text);
        }

        public int ReadKey()
        {
            return (int)Console.ReadKey().Key;
        }

    }

}
