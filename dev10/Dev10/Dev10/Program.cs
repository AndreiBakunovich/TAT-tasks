using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrays creating
            Random rnd = new Random(DateTime.Now.Millisecond);
            int arrayNumber = rnd.Next(5,11);

            double[,] arrayOne = new double[rnd.Next(50, 100), rnd.Next(50, 100)];
            double[,] arrayTwo = new double[rnd.Next(50, 100), rnd.Next(50, 100)];
            double[,] arrayThree = new double[rnd.Next(50, 100), rnd.Next(50, 100)];

            Randomizer gen = new Randomizer();
            gen.RandomFillingArray(arrayOne, rnd);
            gen.RandomFillingArray(arrayTwo, rnd);
            gen.RandomFillingArray(arrayThree, rnd);

            //forming of result
            Checker check = new Checker();
            double[] resCompareOneVSTwo = new double[Convert.ToInt32(Math.Max(arrayOne.GetLength(0) * arrayOne.GetLength(1),
                                              arrayTwo.GetLength(0) * arrayTwo.GetLength(1)) * 0.01)];
            double[] resCompareOneVSThree = new double[Convert.ToInt32(Math.Max(arrayOne.GetLength(0) * arrayOne.GetLength(1),
                                              arrayThree.GetLength(0) * arrayThree.GetLength(1)) * 0.01)];
            double[] resCompareTwoVSThree = new double[Convert.ToInt32(Math.Max(arrayTwo.GetLength(0) * arrayTwo.GetLength(1),
                                              arrayThree.GetLength(0) * arrayThree.GetLength(1)) * 0.01)];
            
            check.Check(arrayOne, arrayTwo, resCompareOneVSTwo);
            check.Check(arrayOne, arrayThree, resCompareOneVSThree);
            check.Check(arrayTwo, arrayThree, resCompareTwoVSThree);

            double[] result = new double[Array.IndexOf(resCompareOneVSTwo, 0) +
                                        Array.IndexOf(resCompareOneVSThree, 0) +
                                        Array.IndexOf(resCompareTwoVSThree, 0)];

            Array.Copy(resCompareOneVSTwo, 0, result, 0, Array.IndexOf(resCompareOneVSTwo, 0));
            Array.Copy(resCompareOneVSThree, 0, result, Array.IndexOf(resCompareOneVSTwo, 0), Array.IndexOf(resCompareOneVSThree, 0));
            Array.Copy(resCompareTwoVSThree, 0, result, Array.IndexOf(resCompareOneVSTwo, 0) + Array.IndexOf(resCompareOneVSThree, 0), Array.IndexOf(resCompareTwoVSThree, 0));

            Console.WriteLine("Final array from the source arrays:");

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(" " + result[i] + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
