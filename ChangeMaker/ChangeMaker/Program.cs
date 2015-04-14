﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling the function with $4.19.  
            //Notice that when using the decimal format you must end numbers with an 'm'
            ChangeAmount(4.17m);
            Console.WriteLine("");

            //calling the function with $3.18
            ChangeAmount(3.18m);
            Console.WriteLine("");
            //calling the function with $0.99
            ChangeAmount(0.99m);
            Console.WriteLine("");
            //calling the function with $12.93
            ChangeAmount(12.93m);

            Console.ReadKey();
        }

        public static Change ChangeAmount(decimal amount) 
        {
            Change tempChange = new Change();

            while (amount > 0m)
            {
                // is there a quarter available
                if (amount >= 0.25m)
                {
                    // take and store the quarter
                    tempChange.Quarters++;
                    amount -= 0.25m;
                }
                // is there a dimes available
                else if (amount >= 0.10m)
                {
                    // take and store the dime
                    tempChange.Dimes++;
                    amount -= 0.10m;
                }
                // is there a nickel available
                else if (amount >= 0.05m)
                {
                    // take and store the nickel
                    tempChange.Nickles++;
                    amount -= 0.05m;
                }
                // is there a penny available
                else if (amount >= 0.01m)
                {
                    // take and store the penny
                    tempChange.Pennies++;
                    amount -= 0.01m;
                }
            }
            return tempChange;
        }

        /// <summary>
        /// Example using the Change class to store data
        /// </summary>
        public static Change Example(decimal amount)
        {
            //creating a new object of our class Change
            Change amountAsChange = new Change();

            //increasing the number of quarters
            amountAsChange.Quarters++;
            amountAsChange.Quarters += 1;
            amountAsChange.Quarters = amountAsChange.Quarters + 1;


            //outputting to the console
            Console.WriteLine("Quarters: " + amountAsChange.Quarters);

            //returning the object
            return amountAsChange;
        }

    }

    public class Change
    {

   

        
        /// <summary>
        /// This is property to hold the number of Quarters to be returned as change
        /// </summary>

        public int Quarters { get; set; }

        /// <summary>
        /// This is property to hold the number of Dimes to be returned as change
        /// </summary>
        public int Dimes { get; set; }

        /// <summary>
        /// This is property to hold the number of Nickles to be returned as change
        /// </summary>
        public int Nickles { get; set; }

        /// <summary>
        /// This is property to hold the number of Pennies to be returned as change
        /// </summary>public int Nickles { get; set; }
        public int Pennies { get; set; }

        /// <summary>
        /// This is a constructor, it initializes a new instance of the class (called an object).  This sets it's default values.
        /// </summary>
        public Change()
        {

            this.Quarters = 0;
            this.Dimes = 0;
            this.Nickles = 0;
            this.Pennies = 0;
        }
    }
}
