using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10.Interfaces
{
    interface IArrayRandomizer
    {
        void RandomFillListArray(List<double[]> arraysList, int minMeans, int maxMeans);
    }
}
