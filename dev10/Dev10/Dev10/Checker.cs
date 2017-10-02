using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10
{
    class Checker
    {
        public double[] Check(double[,] array1, double[,] array2, double[] res)
        {
            int index = 0;
            for (int i = 0; i < array1.GetLength(0); i++)
                for (int j = 0; j < array1.GetLength(1); j++)
                    for (int m = 0; m < array2.GetLength(0); m++)
                        for (int n = 0; n < array2.GetLength(1); n++)
                            if (Math.Abs(array1[i,j] - array2[m,n]) < 1e-6)
                            {
                                res[index] = array1[i,j];
                                index++;
                            }
            return res;
        }
    }
}
