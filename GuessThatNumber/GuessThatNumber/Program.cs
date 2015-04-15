using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        static int NumberToGuess = 0;
        static int guessCounter = 0;
        // store user input
        static int userInput = 0;

        static void Main(string[] args)
        {
            Random rng = new Random();
            // set number to guess
            SetNumberToGuess(rng.Next(1, 101));

            // run loop while user has not guessed the number
            while (userInput != NumberToGuess)
            {
                // Prompt the user for a guess
                Console.Write("Guess a number between 1 and 100: ");
                string tempInput = Console.ReadLine();

                // Check if input is valid
                if(ValidateInput(tempInput))
                {
                    // Good input

                    // check if input is valid
                    if (userInput == NumberToGuess)
                    {
                        Console.WriteLine("Good job you guessed the right number");
                    }
                    else
                    {
                        // not correct number
                        if (IsGuessTooHigh(userInput))
                        {
                            // too high
                            Console.Write("Your guess was too high");
                            if (userInput - NumberToGuess < 20)
                            {
                                Console.Write(", hot\n");
                            }
                            else
                            {
                                Console.Write(", cold\n");
                            }
                        }
                        else
                        {
                            // too low
                            Console.Write("Your guess was too low");
                            if (NumberToGuess - userInput < 20)
                            {
                                Console.Write(", hot\n");
                            }
                            else
                            {
                                Console.Write(", cold\n");
                            }
                        }
                    }
                }
                else
                {
                    // Bad input
                    Console.WriteLine("Invalid input");
                }
            }

            Console.WriteLine("It took {0} guesses", guessCounter);
            Console.ReadKey();

        }
        /// <summary>
        /// validate results to a number 1- 100
        /// </summary>
        /// <param name="userInput">what the user puts in</param>
        /// <returns> nothing, tells gamerunner to stop or keep going</returns>
        public static bool ValidateInput(string userInput)
        {
            // make sure it's not null or empty
            if(userInput != null || userInput != string.Empty)
            {
                // Check if it's a number
                int intResult;
                if (int.TryParse(userInput, out intResult))
                {
                    // Successful parsing
                    // Check if it's within range (1 - 100)
                    if (intResult <= 100 && intResult >= 1)
                    {
                        // within range
                        guessCounter++; // valid guess
                        Program.userInput = intResult;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// for the testers
        /// </summary>
        /// <param name="number"></param>
        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;

        }
        /// <summary>
        /// if the user guess is too high
        /// </summary>
        /// <param name="userGuess">what the user put in for a guess</param>
        /// <returns>true or false depending on rank of guess</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (NumberToGuess < userGuess)
            {
                return true;
            }
            return false;
            //return NumberToGuess < userGuess;

        }
        /// <summary>
        /// if the user guess is too low
        /// </summary>
        /// <param name="userGuess">the user guess</param>
        /// <returns>true or false depending on rank of guess</returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            if (userGuess < NumberToGuess)
            {
                return true;
            } return false;
        }
    }
}
