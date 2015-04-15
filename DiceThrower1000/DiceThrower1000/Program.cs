using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrower1000
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceThrower1000("2d20");
            DiceThrower1000("6d15");
            Console.ReadKey();
        }

        public static void DiceThrower1000(string input)
        {
            int totalSum = 0;
            int totalRolls = 0;

            Random rng = new Random();
            List<string> args = input.Split('d').ToList();
            for (int i = 0; i < int.Parse(args[0]); i++)
            {
                int rollval = rng.Next(1, int.Parse(args[1]) + 1);
                totalSum += rollval;
                Console.Write(rollval + " ");
                totalRolls++;
            }
            Console.WriteLine("avg: {0}", (totalSum/totalRolls));
        }
    }
}
