using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> beerList = new List<string> { "coors", "bud light", "heiniken", "left hand", "odels", "PBR", "blue moon", "PBR", "PBR" };

            // looping with for loop
            Console.WriteLine("For loop");
            for (int i = 0; i < beerList.Count; i++)
            {
                Console.WriteLine(beerList[i]);
            }

            Console.WriteLine("foreach");
            // foreach loop
            foreach (string beerName in beerList)
            {
                if (beerName.Length == 5)
                {
                    Console.WriteLine(beerName);
                }
            }


            Console.WriteLine("Length = 5");
            List<string> letterbeer = beerList.Where(x => x.Length == 5).ToList<string>();
            foreach (string name in letterbeer)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("double where");
            foreach (string eBeer in beerList.Where(xt => xt.Contains("e") || xt.Length > 5).Where(y => y.Length > 2))
            {
                Console.WriteLine(eBeer);
            }

            // Using Distinct
            Console.WriteLine("Using distinct");
            foreach (string distinctName in beerList.Distinct())
            {
                Console.WriteLine(distinctName);
            }

            // use first and last
            Console.WriteLine(beerList.First(x => x.Length > 4));
            Console.WriteLine(beerList.Last());

            // Any
            Console.WriteLine(beerList.Any(x => x.Contains("light") || x.Length > 10));


            // ordered list
            foreach (string names in beerList.OrderBy(x => x))
            {
                Console.WriteLine(names);
            }
            // ordered list
            foreach (string names in beerList.OrderByDescending(x => x.Length))
            {
                Console.WriteLine(names);
            }

            // top 3 longest names
            Console.WriteLine("longest");
            foreach (string longest in beerList.OrderByDescending(x => x.Length).Take(3))
            {
                Console.WriteLine(longest);
            }

            // skip top 3 longest names
            Console.WriteLine("skip top 3 longest");
            foreach (string longest in beerList.OrderByDescending(x => x.Length).Skip(3))
            {
                Console.WriteLine(longest);
            }

            // count # of beers that start with 'bud'
            Console.WriteLine(beerList.Count(x => x.StartsWith("bud")));

            Console.ReadLine();
        }
    }
}
