using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10.Interfaces
{
    interface IListRandomizer
    {
        List<double[]> RandomizeListArray(int arraysCount, int minLength, int maxLength);
    }
}
