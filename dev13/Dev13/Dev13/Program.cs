using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Dev13
{
    class Program
    {
        public static int InputHandler ( string inputValueName )
        {
            Console.WriteLine ( "Enter your {0}.", inputValueName );
            bool inputCorrect = false;
            int input = 0;
            do
            {
                try
                {
                    input = Convert.ToInt32 ( Console.ReadLine() );
                    inputCorrect = true;
                }
                catch
                {
                    Console.WriteLine ( "Input line incorrect. Please, reenter {0}.", inputValueName );
                }
            }
            while ( !inputCorrect );
            return input;
        }

        //pattern strategy had been used heare
        static void Main ( string[] args )
        {
            string inputValueName = "budget";
            int budget = InputHandler ( inputValueName );

            inputValueName = "criterion";
            int criterion = InputHandler ( inputValueName );

            int productivity = 0;
            inputValueName = "productivity";
            if ( criterion != 1 )
            {
                productivity = InputHandler ( inputValueName ) ;
            }

            ICriterion criterionAlgorithm;
            switch ( criterion )
            {
                case 1:
                    {
                        criterionAlgorithm = new FirstCriterion();
                        break;
                    }
                case 2:
                    {
                        criterionAlgorithm = new SecondCriterion();
                        break;
                    }
                default:
                    {
                        criterionAlgorithm = new ThirdCriterion();
                        break;
                    }
            };

            Company EPAM = new Company ( criterionAlgorithm );

            EPAM.FormTeam ( budget , productivity );
            EPAM.PrintLastFormedTeam();

            Console.ReadLine();
        }
    }
}
