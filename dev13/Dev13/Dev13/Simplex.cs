using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev13
{

    /*
        system of limitations:
        a11 * x1 + a12 * x2 + ... + a1n * xn <= b1
        a21 * x1 + a22 * x2 + ... + a2n * xn <= b2
        .
        .
        .
        am1 * x1 + am2 * x2 + ... + amn * xn <= bm

        objective function:
        z = c1 * x1 + c2 * x2 + ... + cn * xn

        input array format:
        {
        { b1 , a11 , a12 , ... , a1n },
        { b2 , a21 , a22 , ... , a2n },
        .
        .
        .
        { bm , am1 , am2 , ... , amn },
        { 0  , -c1 , -c2 , ... , -cn }
        }

        output is array with final array 
    */

    public class Simplex
    {
        //source - simplex table without basis variables
        double [,] table; //simplex table

        int m, n;

        List<int> basis; //list of basis varisbles

        public Simplex ( double [,] source )
        {
            m = source.GetLength ( 0 );
            n = source.GetLength ( 1 );
            table = new double [ m , n + m - 1 ];
            basis = new List<int> ();

            for ( int i = 0 ; i < m ; i++ )
            {
                for ( int j = 0 ; j < table.GetLength ( 1 ) ; j++ )
                {
                    if ( j < n )
                        table [ i , j ] = source [ i , j ];
                    else
                        table [ i , j ] = 0;
                }
                //input coefficient 1 in front of basis var in line
                if ( ( n + i ) < table.GetLength ( 1 ) )
                {
                    table [ i , n + i ] = 1;
                    basis.Add ( n + i );
                }
            }

            n = table.GetLength ( 1 );
        }

        //result - heare will be result X
        public double [,] Calculate ( double [] result )
        {
            int mainCol, mainRow; //Lead line and colomn

            while ( !IsItEnd () )
            {
                mainCol = findMainCol ();
                mainRow = findMainRow ( mainCol );
                basis [ mainRow ] = mainCol;

                double [,] new_table = new double [ m , n ];

                for ( int j = 0 ; j < n ; j++ )
                    new_table [ mainRow , j ] = table [ mainRow , j ] / table [ mainRow , mainCol ];

                for ( int i = 0 ; i < m ; i++ )
                {
                    if ( i == mainRow )
                        continue;

                    for ( int j = 0 ; j < n ; j++ )
                        new_table [ i , j ] = table [ i , j ] - table [ i , mainCol ] * new_table [ mainRow , j ];
                }
                table = new_table;
            }

            //write in result counting X
            for ( int i = 0 ; i < result.Length ; i++ )
            {
                int k = basis.IndexOf ( i + 1 );
                if ( k != -1 )
                    result [ i ] = table [ k , 0 ];
                else
                    result [ i ] = 0;
            }

            return table;
        }

        private bool IsItEnd ()
        {
            bool flag = true;

            for ( int j = 1 ; j < n ; j++ )
            {
                if ( table [ m - 1 , j ] < 0 )
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private int findMainCol ()
        {
            int mainCol = 1;

            for ( int j = 2 ; j < n ; j++ )
                if ( table [ m - 1 , j ] < table [ m - 1 , mainCol ] )
                    mainCol = j;

            return mainCol;
        }

        private int findMainRow ( int mainCol )
        {
            int mainRow = 0;

            for ( int i = 0 ; i < m - 1 ; i++ )
                if ( table [ i , mainCol ] > 0 )
                {
                    mainRow = i;
                    break;
                }

            for ( int i = mainRow + 1 ; i < m - 1 ; i++ )
                if ( ( table [ i , mainCol ] > 0 ) && 
                    ( ( table [ i , 0 ] / table [ i , mainCol ] ) < ( table [ mainRow , 0 ] / table [ mainRow , mainCol ] ) ) )
                    mainRow = i;

            return mainRow;
        }
    }
}
