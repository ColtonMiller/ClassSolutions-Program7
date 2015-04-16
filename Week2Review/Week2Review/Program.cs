using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Review
{
    class Program
    {
        static void Main(string[] args)
        {
            //EverythingAboutLists();
        
            //int someNumber = TryCatch();
            int someNumber = TryParse();
            Console.WriteLine("SomeNumber's value: {0}", someNumber);
            Console.ReadKey();
        }

        //lists
        static void EverythingAboutLists()
        {
            //creating a list
            List<string> myList = new List<string>() {"crackerjacks", "ice cream"};
            myList.Add("peanuts");

            //converting a list to an array and back....
            string[] myArray = myList.ToArray();
            
            List<string> myList2 = myArray.ToList();

            // about Split()
            string stringToSplit = "hi my name is dustin";
            List<string> splitOnTheSpaces = stringToSplit.Split(' ').ToList();
            List<string> splitOnTheZs = stringToSplit.Split('z').ToList();

            //this uses a custom function that does the same thing.
            List<string> splitOnTheSpaces2 = Split(stringToSplit, ' ');
            List<string> splitOnTheZs2 = Split(stringToSplit, 'z');


            //break point
            var x = 1;
        }

        static List<string> Split(string stringToSplit, char seperator)
        {
            List<string> splitList = new List<string>();
            string tempStringToHoldLetters = string.Empty;
            for (int i = 0; i < stringToSplit.Length; i++)
            {
                char letter = stringToSplit[i];
                if (letter == seperator)
                {
                    splitList.Add(tempStringToHoldLetters); //add ot the array
                    tempStringToHoldLetters = string.Empty; // clear our letter holder
                }
                else
                {
                    //not our seperator, add it to the temp string
                    tempStringToHoldLetters += letter.ToString();
                }
             }
            //after the loop completes, add to temp string to the list.  adds the last letters
            splitList.Add(tempStringToHoldLetters);

            return splitList;
        }

        static int TryCatch()
        {
            //a good way to validate numeric input

            //try...catch is used for graceful error handling.
            try
            {
                int parseInt = int.Parse(Console.ReadLine());
                return parseInt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                return TryCatch();
            }
            
        }

        static int TryParse()
        {
            int parsedInt = 0; //integer holder for the conversion of userInput to a integer, if it is successful
            Console.Write(">> ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out parsedInt))
            {
                //the parse succeeded
                return parsedInt;
            }
            else
            {
                //failed, could not parse an integer from the userInput
                // call itself again for more input
                return TryParse();
            }
        }
    }
}
