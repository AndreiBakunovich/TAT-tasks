using System;

namespace task_01
{
    class Program
    {
        // this program check is path valid
        static void Main ( string [] args )
        {
            bool possiblePath = true;
            try
            {
                Checker MyChecker = new Checker();
                possiblePath = MyChecker.Check(args[0]);
            }
            catch
            {
                Console.WriteLine ( "Wrong source file format or incorrect path to them!" );
                return;
            }
            Console.WriteLine ( "Path is {0}." , possiblePath );
        }
    }
}
