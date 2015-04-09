using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //entry point to our code
            Console.WriteLine("Hello World!");

            //call my function
            ForLoopPractice();

            Greet("Dustin");
            Greet("that dude from nickleback");

            Console.WriteLine(Multiply(3, 4));

            int doubleMyAge = Multiply(32, 2);

            Console.WriteLine(Multiply(doubleMyAge, 4));
            Console.WriteLine(Multiply(2, Multiply(3, Multiply(6, 12))));

            Looper(5);
            Looper(15);
            Looper(Multiply(3, doubleMyAge));

            //last line of the main function
            //keep the window open
            Console.ReadKey();
        }

        //declare new functions outside of other functions, but still inside of a class.


        static void ForLoopPractice()
        {
            //anytime this function is called, this code will run
            for (int i = 0; i <= 1000; i = i + 100)
            {
                //for each iteration of the loop, run this code
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Greets the user by name, prints to the console
        /// </summary>
        /// <param name="name">The name of the user</param>
        static void Greet(string name)
        {
            Console.WriteLine("Hello, " + name + ".");
        }

        /// <summary>
        /// return the product of two integers
        /// </summary>
        /// <param name="number1">first number to multiply</param>
        /// <param name="number2">second number to multiply</param>
        /// <returns>the product of the two integers</returns>
        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        //write a function called 'Looper' that takes in a integer parameter called 'loopUntil', which then prints out the numbers between 1 and loopUntil.

        static void Looper(int loopUntil)
        {
            for (int i = 1; i <= loopUntil; i = i + 1)
            {
                Console.WriteLine(i);
            }
        }

    }
}
