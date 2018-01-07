using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev13
{
    class FirstCriterion : ICriterion
    {
        //release of first criterion algorithm
        public int [] SelectTeam ( int [] [] paramsOfProgrrammers , int productivity , int budget )
        {
            double [] result = new double [ paramsOfProgrrammers.GetLength ( 0 ) ];

            double [,] arrayForSimplex = FormArrayForSimplex ( paramsOfProgrrammers , budget );
            double [,] resultOfSimplex;

            Simplex mySimplex = new Simplex ( arrayForSimplex );
            resultOfSimplex = mySimplex.Calculate ( result );

            int [] resInt = new int [ paramsOfProgrrammers.GetLength ( 0 ) ];
            for ( int i = 0 ; i < result.Length ; i++ )
            {
                resInt [ i ] = Convert.ToInt16 ( result [ i ] );
            }

            return resInt;
        }

        //form array in according with Simplex class requirements
        private double [,] FormArrayForSimplex ( int [] [] paramsOfProgrrammers , int budget )
        {
            int sizeLine = 2;
            int sizeColumn = paramsOfProgrrammers.GetLength ( 0 ) + 1;
            double [,] result = new double [ sizeLine , sizeColumn ];

            for ( int i = 1 ; i < sizeColumn ; i++ )
            {
                result [ 0 , i ] = paramsOfProgrrammers [ i - 1 ] [ 0 ];
                //Console.WriteLine ( "result [ 0, {0} ] =!{1}!", i , result [ 0 , i ]);
            }
            result [ 0 , 0 ] = budget;

            for ( int i = 1 ; i < sizeColumn ; i++ )
            {
                result [ 1 , i ] = -1 * paramsOfProgrrammers [ i - 1 ] [ 1 ];
                //Console.WriteLine ( "result [ 1, {0} ] =!{1}!", i , result [ 1 , i ]);
            }
            result [ 1 , 0 ] = 0;

            return result;
        }

    }
}
