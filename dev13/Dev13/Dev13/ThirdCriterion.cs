using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev13
{
    class ThirdCriterion : ICriterion
    {
        //release of first criterion algorithm
        public int [] SelectTeam ( int [] [] paramsOfProgrrammers , int productivity , int budget )
        {
            double [] result = new double [ paramsOfProgrrammers.GetLength ( 0 ) ];

            double [,] arrayForSimplex = FormArrayForSimplex ( paramsOfProgrrammers , budget , productivity );

            Simplex mySimplex = new Simplex ( arrayForSimplex );
            arrayForSimplex = mySimplex.Calculate ( result );

            int [] resInt = new int [ paramsOfProgrrammers.GetLength ( 0 ) ];
            for ( int i = 0 ; i < result.Length ; i++ )
            {
                resInt [ i ] = Convert.ToInt32 ( result [ i ] );
            }

            return resInt;
        }

        //form array in according with Simplex class requirements
        private double [,] FormArrayForSimplex ( int [] [] paramsOfProgrrammers , int budget , int productivity )
        {
            int sizeLine = 4;
            int sizeColumn = paramsOfProgrrammers.GetLength ( 0 ) + 1;
            double [,] result = new double [ sizeLine , sizeColumn ];

            for ( int i = 1 ; i < sizeColumn ; i++ )
            {
                result [ 0 , i ] = paramsOfProgrrammers [ i - 1 ] [ 0 ];
            }
            result [ 0 , 0 ] = budget;

            for ( int i = 1 ; i < sizeColumn ; i++ )
            {
                result [ 1 , i ] = paramsOfProgrrammers [ i - 1 ] [ 1 ];
            }
            result [ 1 , 0 ] = productivity;

            for ( int i = 1 ; i < sizeColumn ; i++ )
            {
                result [ 2 , i ] = -1 * paramsOfProgrrammers [ i - 1 ] [ 1 ];
            }
            result [ 2 , 0 ] = -productivity;

            for ( int i = 2 ; i < sizeColumn ; i++ )
            {
                result [ 3 , i ] = -1;
            }
            result [ 3 , 1 ] = 0;
            result [ 3 , 0 ] = 0;

            return result;
        }
    }
}
