using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev10.Interfaces;

namespace Dev10
{
    class ArrayBuilder
    {
        private IArrayRandomizer arrayRandomizer;

        public ArrayBuilder(IArrayRandomizer arrayRandomizer)
        {
            this.arrayRandomizer = arrayRandomizer;
        }

        // Collect numbers in one array from List. That's numbers exists minimum in two arrays of List.
        public double[] ArrayBuild(List<double[]> arraysList, int minMeans, int maxMeans)
        {
            //filling of arrays by random numbers
            arrayRandomizer.RandomFillListArray(arraysList, minMeans, maxMeans);
            Checker check = new Checker();
            int maxSizeOfArray = 0;
            foreach (double[] array in arraysList)
                if (array.Length > maxSizeOfArray)
                    maxSizeOfArray = array.Length;
            double[] result = new double[Convert.ToInt32(arraysList.Count * maxSizeOfArray * 0.01)];

            //Checking list for existing simular numbers and forming by them result array
            int iterator = 0;
            for (int i = 0; i < arraysList.Count - 1; i++)
                for (int j = 0; j < arraysList[i].Length; j++)
                    for (int n = i + 1; n < arraysList.Count; n++)
                        for (int m = 0; m < arraysList[n].Length; m++)
                            if (check.EqualsDouble(arraysList[i][j], arraysList[n][m]))
                            {
                                result[iterator] = arraysList[i][j];
                                iterator++;
                            }

            return result;
        }
    }
}
