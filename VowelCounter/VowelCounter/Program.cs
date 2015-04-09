using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // "test"
            // "0123"
            Console.WriteLine("Vowels in the string: " + VowelCounterEasier("test"));
            Console.ReadKey();
        }
        public static int VowelCounter(string inputText)
        {
            int counter = 0;
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == 'a' || inputText[i] == 'e' || inputText[i] == 'i' || inputText[i] == 'o' || inputText[i] == 'u')
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int VowelCounterEasier(string inputText)
        {
            int counter = 0;
            for (int i = 0; i < inputText.Length; i++)
            {
                if ("aeiou".Contains(inputText[i]))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
