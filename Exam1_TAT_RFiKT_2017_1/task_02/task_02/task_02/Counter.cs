using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_02
{
    public class Counter
    {
        public int Count ( List<string> listOfElements )
        {
            int res = 0;

            listOfElements.Sort();

            if (listOfElements.Count == 1)
            {
                return 1;
            }
            else if ( listOfElements.Count == 0 )
            {
                return 0;
            }

            bool isElementRepeated = false;
            for ( int i = 0 ; i < listOfElements.Count - 1 ; i++ )
            {
                if ( listOfElements [ i ].Equals( listOfElements [ i + 1 ] ) )
                {
                    isElementRepeated = true;
                }
                else if ( !isElementRepeated )
                {
                    res++;
                }
                else
                {
                    isElementRepeated = false;
                }
            }

            return res;
        }
    }
}
