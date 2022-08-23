using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "hola-mundo";
            SelectMenu(text);
        }

        private static void SelectMenu(string text)
        {
            var op = Menu();
            var sop = "";
            string val;
            do
            {
                switch (op)
                {
                    case "1":
                        Stamp.Print("1 - Create Qr");
                        val = GetInput(text);
                        if (Qr.Create(val))
                        {
                            Stamp.Print("Qr saved in " + Qr.GetDirectory());
                        }
                        else
                        {
                            Stamp.Print("Qr cann't created.");
                        }

                        Stamp.Print("\n\nContinue? (y): ", false);
                        sop = Console.ReadLine();
                        sop = sop.ToLower();
                        break;

                    default:
                        break;
                }

                if (sop != "y")
                {
                    op = Menu();
                }

            }
            while (op != "2"); // Cuando opcion sea 2 salir
        }

        private static string Menu()
        {
            Stamp.Clear();
            Stamp.WriteLine("OPTIONS MENU");
            Stamp.WriteLine("1 - Generate Qr");
            Stamp.WriteLine("2 - Exit");
            Stamp.Write("\nSelect a option: ");
            return Console.ReadLine();
        }


        private static string GetInput(string val)
        {
            string iValue;
            Stamp.Print("\nUse default text? (y): ", false);
            iValue = Console.ReadLine();
            iValue = iValue.ToLower();
            if (iValue != "y")
            {
                Stamp.Print("\nInput text: ", false);
                iValue = Console.ReadLine();
            }
            else
            {
                iValue = val;
            }
                
            Stamp.Print("Text for text: " + iValue);

            return iValue;
        }
    }
}
