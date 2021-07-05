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
            Console.ForegroundColor = ClosestConsoleColor(foreColor.R,foreColor.G,foreColor.B);
            Console.Write(text);
        }

        public int ReadKey()
        {
            return (int)Console.ReadKey().Key;
        }

        static ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
        {
            ConsoleColor ret = 0;
            double rr = r, gg = g, bb = b, delta = double.MaxValue;

            foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
            {
                var n = Enum.GetName(typeof(ConsoleColor), cc);
                var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
                var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);
                if (t == 0.0)
                    return cc;
                if (t < delta)
                {
                    delta = t;
                    ret = cc;
                }
            }
            return ret;
        }

    }

}
