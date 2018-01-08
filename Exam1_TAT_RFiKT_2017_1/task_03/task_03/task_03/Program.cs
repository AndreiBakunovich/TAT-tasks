using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // get from console number of cars
            uint countOfCars = 0;
            bool isCorrect = false;
            while ( !isCorrect )
            {
                try
                {
                    Console.WriteLine("Enter number of cars.");
                    countOfCars=Convert.ToUInt32(Console.ReadLine());
                    isCorrect=true;
                }
                catch
                {
                    Console.WriteLine("Entered value is incorrect.");
                }
            }

            // fill list of cars from console
            List<Car> listOfCars = new List<Car>();
            ConsoleCarHandler consoleCarHandler = new ConsoleCarHandler();
            for ( int i = 0; i<countOfCars; i++ )
            {
                listOfCars.Add(consoleCarHandler.GetCorrectCar());
            }

            // sorting list of cars
            listOfCars.Sort();

            // print sorted list on console
            Console.WriteLine("Sorted list of cars.");
            foreach ( Car mem in listOfCars )
            {
                Console.WriteLine(mem.ToString());
            }
        }
    }
}
