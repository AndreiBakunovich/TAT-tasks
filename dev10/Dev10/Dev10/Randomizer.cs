using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev10.Interfaces;

namespace Dev10
{
    class Randomizer: IListRandomizer,IArrayRandomizer
    {
        //grenerate arrays with random size and fill List by them
        public List<double[]> RandomizeListArray(int arraysCount, int minLength, int maxLength)
        {
            List<double[]> arraysList = new List<double[]>();

            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arraysCount; i++)
                arraysList.Add(new double[rnd.Next(minLength, maxLength)]);

            return arraysList;
        }

        //grenerate random numbers and fill List of arrays by them
        public void RandomFillListArray(List<double[]> arraysList, int minMeans, int maxMeans)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            foreach (double[] array in arraysList)
                for (int i = 0; i < array.Length; i++)
                    array[i] = minMeans + rnd.NextDouble() * (maxMeans - minMeans);
        }
    }
}
