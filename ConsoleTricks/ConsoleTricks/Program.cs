using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTricks
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("whoa, i'm a cool color");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("back to white");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("pretty hard to read, huh?");

            Console.ReadKey(); //pause before screen clear

            Console.Clear(); // clears the screen

            //write at specific locations
            Console.SetCursorPosition(5, 15);
            Console.Write("something");

            Console.SetCursorPosition(12, 7);
            Console.Write("something");

            //how to write multiple lines
            Console.WriteLine(@"
                                                                                                 
  _____ ___.__. _____ __  _  __ ____   __________   _____   ____      _________    _____   ____  
 /     <   |  | \__  \\ \/ \/ // __ \ /  ___/  _ \ /     \_/ __ \    / ___\__  \  /     \_/ __ \ 
|  Y Y  \___  |  / __ \\     /\  ___/ \___ (  <_> )  Y Y  \  ___/   / /_/  > __ \|  Y Y  \  ___/ 
|__|_|  / ____| (____  /\/\_/  \___  >____  >____/|__|_|  /\___  >  \___  (____  /__|_|  /\___  >
      \/\/           \/            \/     \/            \/     \/  /_____/     \/      \/     \/ 
");

            string input = Console.ReadLine(); 
           
            //validating user input
            int test = int.Parse(input);

            int intInput = 0;
            while(!int.TryParse(input, out intInput))
            {
                //get more input
                Console.WriteLine("invalid, please try again");
            }


            Console.ReadKey();
        }
    }
}
