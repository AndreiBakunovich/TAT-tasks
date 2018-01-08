using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace task_02
{
    class Program
    {
        public static void Main ( string [] args )
        {
            string path = @"f:\Test\ControlWorkFirst\TAT0003.test01\task_02\task_02\task_02\SourceFile.txt";
            List<string> listOfElements = new List<string>();
            string[] stringArrayOfElements = File.ReadAllLines ( path );

            for ( int i = 0 ; i < stringArrayOfElements.Length ; i++ )
            {
                listOfElements.Add ( stringArrayOfElements [ i ] );
            }

            listOfElements.ForEach ( Console.WriteLine );

            Counter counter = new Counter();
            int result = counter.Count ( listOfElements );

            Console.WriteLine ( "The number of repeated elements is {0}.",result );
        }
    }
}
