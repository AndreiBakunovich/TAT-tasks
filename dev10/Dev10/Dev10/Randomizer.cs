using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10
{
    class Randomizer
    {
        public void RandomFillingArray(double[,] array, Random rnd)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i,j] = rnd.NextDouble() * 100;
        }
    }
}
