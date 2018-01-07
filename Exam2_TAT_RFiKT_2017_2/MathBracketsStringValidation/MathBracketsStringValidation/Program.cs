using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathBracketsStringValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckerForBrackets checkerForBrackets = new CheckerForBrackets();
            Console.WriteLine("Is string '{1}' can be maths expression? \nAnswer: {0}.", checkerForBrackets.Check(args[0]), args[0]);
        }
    }
}