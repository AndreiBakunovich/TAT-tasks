using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev13
{
    interface ICriterion
    {
        int[] SelectTeam ( int[][] parametersOfProgrrammers , int productivity );
    }
}
