using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaReview
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> nameList = new List<string>() { "bert", "cookie monster", "ernie", "snufalufagus" };

            List<string> namesWithAnOLambda = nameList.Where(x => x.ToLower().Contains("o")).ToList();

            //foreach loop that the lambda gets translated to
            List<string> resultListForNamesWithAnO = new List<string>();
            for (int i = 0; i < nameList.Count; i++)
            {
                string x = nameList[i];
                if (x.ToLower().Contains("o"))
                {
                    resultListForNamesWithAnO.Add(x);
                }
            }

            int numberOfNamesWithAQLambda = nameList.Count(x => x.Contains("q"));
            
            //lambda as a foreach
            int numberOfNamesWithAQ = 0;
            foreach (string x in nameList)
            {
                if (x.Contains("q"))
                {
                    numberOfNamesWithAQ++;
                }
            }

            double averageNumberOfLettersLambda = nameList.Average(x => x.Length);

            //translate that into a foreach loop (for an average)
            double totalNumberOfItems = 0;
            double totalSum = 0;
            foreach (string x in nameList)
            {
                totalNumberOfItems++; //processed one item
                totalSum += x.Length; //add its number of letters to the total
            }
            double averageNumber = totalSum / totalNumberOfItems;
        }
    }
}
