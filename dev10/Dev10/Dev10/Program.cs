using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10
{
    class Program
    {
        private const int arrayNumber = 6;
        private const int minLengtOfArray = 5000;
        private const int maxLengtOfArray = 10000;
        private const int minMeanInArray = 0;
        private const int maxMeanInArray = 100;

        static void Main(string[] args)
        {
            //arrays creating
            List<double[]> arraysList = new List<double[]>();
            Randomizer randomizer = new Randomizer();
            ArrayBuilder arrayBuild = new ArrayBuilder(randomizer);
            arraysList = randomizer.RandomizeListArray(arrayNumber, minLengtOfArray, maxLengtOfArray);

            //forming of result
            double[] result = arrayBuild.ArrayBuild(arraysList, minMeanInArray, maxMeanInArray);
            Console.WriteLine("Final array from the source arrays:");

            //print of result
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(" " + result[i] + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
