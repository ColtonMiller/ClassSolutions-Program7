using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Review
{
    class Program
    {
        static void Main(string[] args)
        {
            SpecificLetterCounter("s", "sally SELLS SEASHELLS");

            ////}
            Console.WriteLine(NumberRounder(12));
            Console.WriteLine(NumberRounder(16));
            Console.WriteLine(NumberRounder(19));
            Console.WriteLine(NumberRounder(19112341));

            Console.WriteLine(AnNoYiNgTeXtIfYeR("this is annoying and hard to read.  i am so 90s.  aol teen chat 13. a/s/l?"));

            string withFirstLetterCapitalized = CapitalizeFirstLetter("biscuits");

            //keep console open until key press
            Console.ReadKey();
        }

        /// <summary>
        /// Takes in a string, removes all the spaces
        /// </summary>
        /// <param name="inputString">string to despacify</param>
        /// <returns>a string with no faces</returns>
        static string SpaceRemover(string inputString)
        {
            return "";
        }

        /*  i'm a comment
         * and i go many
         * lines 
         * deep
         * stuff */


        static void DeclaringVariables()
        {
            //declaring a variable
            int count = 10;
            while (count < 20)
            {
                count++;
            }

            //int count = 0   -- wrong, doesnt work
            count = 0;
            while (count < 10) { count++; }
        }

        /// <summary>
        /// Counts the number of instances of a specific letter in a string.  Print that number to the console.
        /// </summary>
        /// <param name="letterToCount">letter to count</param>
        /// <param name="stringToSearch">string to search</param>
        static void SpecificLetterCounter(string letterToCount, string stringToSearch)
        {
            //SpecificLetterCounter("a", "Lamond");
            int numberOfMatchesCounter = 0; //hold the number of matches found

            //loop through each letter of the string
            for (int i = 0; i < stringToSearch.Length; i++) 
            { 
                //get a letter
                string letter = stringToSearch[i].ToString();
                //comparing the current letter with the letter we are trying to find.  making sure both are in lowercase.
                if (letter.ToLower() == letterToCount.ToLower()) 
                {
                    //if found one, add one to the counter
                    numberOfMatchesCounter++;
                }
            }  
          
            //Output: 
            // <stringToSearch> has <X> letterToCount's in it
            // Sally is sunny has 3 s's in it
            Console.WriteLine("{0} has {1} {2}'s in it", stringToSearch, numberOfMatchesCounter, letterToCount);

            //both of the Console.WriteLines do the same thing.
            //Console.WriteLine(stringToSearch + " has " + numberOfMatchesCounter + " " + letterToCount + "'s in it");
        }





        // input: 7  output: 5
        // input: 2  output: 0
        // input: 9  output: 10
        // input: 13 output: 15
        // input: 19 output: 20
        /// <summary>
        /// NumberRounder, rounds an integer to the nearest 5
        /// </summary>
        /// <param name="numberToRound">number to round off</param>
        /// <returns>nearest 5</returns>
        static int NumberRounder(int numberToRound)
        {
            
             //* 1 % 5 = 1 down
             //* 2 % 5 = 2 down
             //* 3 % 5 = 3 up
             //* 4 % 5 = 4 up
             //* 5 % 5 = 0 nothing
             //* 6 % 5 = 1 down
             //* 7 % 5 = 2 down
             //* 8 % 5 = 3 up
             //* 9 % 5 = 4 up
            
            int remainder = numberToRound % 5;
            if (remainder >= 3)
            {
                //round up (ie. 8 + (5 - 3) == 10)
                numberToRound = numberToRound + (5 - remainder);
            }
            else
            {
                //round down  (ie. 6 - 1 == 5)
                numberToRound = numberToRound - remainder;
            }

            return numberToRound;
        }

        /// <summary>
        /// Take in a string, it will return a string with letters alternation between upper and lower case.
        /// </summary>
        /// <param name="notAnnoyingString">string to make annoying</param>
        /// <returns>hard to read string</returns>
        public static string AnNoYiNgTeXtIfYeR(string notAnnoyingString)
        {
            //input:  "nickleback"
            //output: "NiCkLeBaCk"
            // declare a return string for output
            string returnString = string.Empty;
            //looping over every letter
            for (int i = 0; i < notAnnoyingString.Length; i++)
            {
                //get a letter to examine
                string letter = notAnnoyingString[i].ToString();
                //see if the position of the letter is odd or even
                if (i % 2 == 0) { 
                //even, make it CAPITAL
                    returnString = returnString + letter.ToUpper();
                }
                else
                {
                    //odd, make that sucka small
                    returnString += letter.ToLower();
                }
                

            }              
                //loop finished, return the return string
            return returnString;
        }

        static string CapitalizeFirstLetter(string inputString)
        {
            //logic to capitalize the first letter
            return inputString;
        }

        static void ListOperations()
        {
            List<string> myList = new List<string>() { "hall", "and", "oates" };
            List<string> emptyList = new List<string>();

            string tempString = myList[1];

            //remove from a list
            myList.Remove(tempString);

            //add a value to the empty list
            emptyList.Add(tempString);

        }

        static int Multiply(int number1, int number2) 
        {
            return number1 * number2;
        }

        static int Multiply(int number1, int number2, int number3)
        {
            return number1 * number2 * number3;
        }

    }

}
