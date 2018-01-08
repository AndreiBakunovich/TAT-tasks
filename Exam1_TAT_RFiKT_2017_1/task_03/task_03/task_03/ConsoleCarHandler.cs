using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_03
{

    public class ConsoleCarHandler
    {
        // return correct input of string from console
        private string GetStringFromConsole(string nameOfReturnValue)
        {
            string result = String.Empty;
            var isCorrect = false;
            while ( !isCorrect )
            {
                try
                {
                    Console.WriteLine("Enter the cars {0}." , nameOfReturnValue);
                    result=Console.ReadLine();
                    isCorrect=true;
                }
                catch
                {
                    Console.WriteLine("Entered value is incorrect.");
                }
            }
            return result;
        }

        public Car GetCorrectCar()
        {
            Car result = new Car();
            result.mark=GetStringFromConsole("mark");
            result.model=GetStringFromConsole("model");
            result.type=GetStringFromConsole("type");

            bool isCorrect = false;
            while ( !isCorrect )
            {
                try
                {
                    Console.WriteLine("Enter the price of car.");
                    result.price=Convert.ToDouble(Console.ReadLine());
                    isCorrect=true;
                }
                catch
                {
                    Console.WriteLine("Entered value is incorrect.");
                }
            }

            return result;
        }
    }
}
