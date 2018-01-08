using System;

namespace task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            INextShot consoleReader = new ConsoleReader();
            SeaBattle seaBattle = new SeaBattle(consoleReader);
            seaBattle.StartBattle();
            Console.WriteLine("The number of ships is {0}. \nThe number of shots is {1}.", seaBattle.GetNumberOfShipsOnStart(), seaBattle.GetCountOfShots());
        }
    }
}
