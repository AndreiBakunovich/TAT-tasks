using System;

namespace Exam2_task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number to convert to integer.");
                string toInt = Console.ReadLine();
                Converter converter = new Converter();
                Console.WriteLine("Integer number is {0}.",converter.ConvertToInt(toInt));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
