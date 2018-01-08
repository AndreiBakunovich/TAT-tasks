using System;

namespace task_04
{
    class ConsoleReader : INextShot
    {
        private const int ASCIICodeOfa = 97;
        private const int ASCIICodeOf0 = 48;

        ///<summary>
        ///This methode read from console next coordinate of shot and check it format.
        ///First symbol - letter from a to j, second - number from 0 to 9.
        ///</summary>

        public string GetNextShot()
        {
            string coordinate = String.Empty;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter coordinate for the shot. \nFirst - letter from {0} to {1}, second - number from {2} to {3}.",
                                     (char)ASCIICodeOfa, (char)(ASCIICodeOfa + 9), (char)ASCIICodeOf0, (char)(ASCIICodeOf0 + 9));
                    coordinate = Console.ReadLine();
                    if (coordinate == String.Empty || coordinate.Length != 2)
                    {
                        Console.WriteLine("Wrong coordinate formate.");
                        continue;
                    }
                    if (coordinate[0] < ASCIICodeOfa || coordinate[0] > ASCIICodeOfa + 9)
                    {
                        Console.WriteLine("Wrong coordinate formate.");
                        continue;
                    }
                    if (coordinate[1] < ASCIICodeOf0 || coordinate[1] > ASCIICodeOfa + 9)
                    {
                        Console.WriteLine("Wrong coordinate formate.");
                        continue;
                    }
                    return coordinate;
                }
                catch
                {
                    Console.WriteLine("Wrong coordinate formate.");
                    continue;
                }
            }
        }
    }
}
