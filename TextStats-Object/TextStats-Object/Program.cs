using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStats_Object
{
    class TextStats
    {
        private string inputString = string.Empty;
        public int NumOfVowels { get; set; }
        public int NumOfCons { get; set; }
        public int NumSpecial { get; set; }
        public string LongestWordString { get; set; }
        public string ShortestWordString { get; set; }

        public TextStats(string stringToAnalyze)
        {
            this.inputString = stringToAnalyze;
            this.LongestWordString = LongestWord();
            this.ShortestWordString = ShortestWord();
            this.NumOfCons = NumberOfConsonants();
            this.NumOfVowels = NumberOfVowels();
            this.NumSpecial = NumberOfSpecialCharacters();
        }
        public void PrintResults()
        {
            Console.WriteLine("{0} vowels", this.NumOfVowels);
            Console.WriteLine();
        }

        public static int DoSomething(int num1, int num2)
        {
            return num1 * num2;
        }
        private int NumberOfWords()
        {
            //splits string by spaces and turns them into a list. Counts the indexes in the list, which turns out to be the number of words
            return inputString.Split(' ').ToList().Count;
        }

        private int NumberOfVowels()
        {
            //making all the letters of input string to lower and then checking if they contain any vowels
            return inputString.ToLower().Count(x => ("aeiou".Contains(x)));

        }

        private int NumberOfConsonants()
        {
            //making all the letters of input string tolower and then checking if they contain any consonants
            return inputString.ToLower().Count(x => ("bcdfghjklmnpqrstvwxyz").Contains(x));
        }

        private int NumberOfSpecialCharacters()
        {
            // .,?;'!@#$%^&*() and spaces are considered special characters
            return inputString.Count(x => (" .,?;'!@#$%^&*()").Contains(x));
        }

        private string LongestWord()
        {
            //splitting the inputString by the spaces so it gets individual words, then orders from longest to shortest. Then pulls out the first which is the longest
            return inputString.Split(' ').ToList().OrderByDescending(x => x.Length).First();
        }

        private string ShortestWord()
        {
            //spliiting the string by spaces to get words. Order it by shortest to longest and then pulls out the first which is the shortest
            return inputString.Split(' ').ToList().OrderBy(x => x.Length).First();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            TextStats myWord = new TextStats("Mike's favorite color is blue.");
            Console.WriteLine(myWord.NumOfCons);
            Console.WriteLine(myWord.NumOfVowels);
            myWord.PrintResults();
            TextStats.DoSomething(2, 3);
            Console.ReadKey();
        }
    }
}
