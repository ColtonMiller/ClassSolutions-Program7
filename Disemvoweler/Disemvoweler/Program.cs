using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call Disemvoweler with all of the required phrases
            Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!");
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?");
            Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls.");
            // keep the console open
            Console.ReadKey();
        }
        public static string Disemvoweler(string input)
        {
            StringBuilder tempVowel = new StringBuilder();
            StringBuilder tempCons = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if ("aeiou".Contains(input[i].ToString().ToLower()))
                {
                    // is vowel char
                    tempVowel.Append(input[i]);
                }
                else if ("bcdfghjklmnpqrstvwxyz".Contains(input[i].ToString().ToLower()))
                {
                    // is cons char
                    tempCons.Append(input[i]);
                }
            }
            Console.WriteLine("original {0}",input);
            Console.WriteLine("vowels {0}", tempVowel.ToString());
            Console.WriteLine("cons {0}", tempCons.ToString());
            return tempCons.ToString();
        }
    }
}
