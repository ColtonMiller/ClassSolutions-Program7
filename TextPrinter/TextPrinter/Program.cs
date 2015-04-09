using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            TextPrinter("Colton's favorite band is nickelback.");
            Console.ReadKey();
        }
        public static void TextPrinter(string inputText)
        {
            for (int i = 0; i < inputText.Length; i++)
            {
                Console.Write(inputText[i]);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
