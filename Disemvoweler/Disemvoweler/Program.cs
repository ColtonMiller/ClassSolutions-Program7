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
            //Call the function for the input strings
            Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!");
            Console.WriteLine();
            Disemvoweler("How many bears could Bear Grylls grill if Bear Grylls could grill bears?");
            Console.WriteLine();
            Disemvoweler("I'm a code ninja, baby. I make the function and I make the calls.");

            // keep the console open
            Console.ReadKey();
        }
        public static string Disemvoweler(string input)
        {
            //Make all characters lower case
            string lowerInput = input.ToLower();
            //Turn string into an array
            char[] stringArray = lowerInput.ToCharArray();
            //Create list for all characters execpt vowels and special characters
            List<char> disemvoweledList = new List<char>();
            //Create list for all vowels
            List<char> vowelList = new List<char>();

            //Check every character
            for (int i = 0; i < stringArray.Length; i++)
            {
                //check for vowels
                if ("aeiou".Contains(stringArray[i].ToString()))
                {
                    //add vowels to vowelList
                    vowelList.Add(stringArray[i]);
                }
                //check for all letters escept vowels
                else if ("bcdfghjklmnpqrstvwxyz".Contains(stringArray[i].ToString()))
                {
                    //adds characters to disemvoweledList
                    disemvoweledList.Add(stringArray[i]);
                }
            }

            //converts the lists into strings
            string disemvoweledString = string.Join("", disemvoweledList);
            string vowelString = string.Join("", vowelList);

            // Write out the various string results
            Console.WriteLine("Original: {0}", input);
            Console.WriteLine("Disemvoweled: {0}", disemvoweledString);
            Console.WriteLine("Vowels Removed: {0}", vowelString);
            // Return the Disemvoweled string as well for testing
            return disemvoweledString;
        }
    }
}
