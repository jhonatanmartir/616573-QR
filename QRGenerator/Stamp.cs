using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGenerator
{
    using System;

    public class Stamp
    {
        private const string HEADER = "QrGenerator:~# ";
        private static readonly ConsoleColor primaryColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor secondaryColor = ConsoleColor.Gray;

        public static void Print(string text)
        {
            Console.ForegroundColor = primaryColor;
            Console.Write(HEADER);
            Console.ForegroundColor = secondaryColor;
            Console.WriteLine(text);
        }
        public static void Print(string text, bool line = true)
        {
            Console.ForegroundColor = primaryColor;
            if (line)
                Console.WriteLine(text);
            else
            {
                Console.Write(text);
                Console.ForegroundColor = secondaryColor;
            }
        }
        public static void WriteLine(string text)
        {
            Console.ForegroundColor = primaryColor;
            Console.WriteLine(text);
        }
        public static void Write(string text)
        {
            Console.ForegroundColor = primaryColor;
            Console.Write(text);
            Console.ForegroundColor = secondaryColor;
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }

}
