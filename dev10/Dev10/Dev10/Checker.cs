using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev10
{
    class Checker
    {
        private const double eps = 1e-5;

        //check for equals of two double numbers
        public bool EqualsDouble(double a, double b)
        {
            if (Math.Abs(a - b) < eps) return true;
            else return false;
        }
    }
}
