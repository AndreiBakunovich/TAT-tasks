using System;
using System.Collections.Generic;
using System.Text;

namespace task_04
{
    /// <summary>
    /// Provides methods for sea battle.
    /// </summary>
    public class SeaBattle
    {
        private int countOfShots;
        private int maximumNumberOfShips;
        private int numberOfShips;
        private const int ASCIICodeOfa = 97;
        private int fieldSize;
        private List<string> shipCoordinate;
        private INextShot nextShot;

        /// <summary>
        /// Constractor initialise field size, number of ships, source of next shot and ships coordinate.
        /// </summary>
        /// <param>
        /// <param name="nextShot">
        /// </param>

        public SeaBattle(INextShot nextShot)
        {
            // number of ships limited by field size
            maximumNumberOfShips = 16;
            fieldSize = 9;
            Random random = new Random(DateTime.Now.Millisecond);
            numberOfShips = random.Next(1, maximumNumberOfShips + 1);
            shipCoordinate = new List<string>();
            shipCoordinate = GenerateShipsCoordinate();
            this.nextShot = nextShot;
            shipCoordinate.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Start game 'sea battle'.
        /// </summary>
        public void StartBattle()
        {
            while (!IsFieldEmpty())
            {
                ShutInField(nextShot.GetNextShot());
            }
        }

        /// <summary>
        /// Retern number of ships on start.
        /// </summary>
        public int GetNumberOfShipsOnStart()
        {
            return numberOfShips;
        }

        private bool ShutInField(string coordinate)
        {
            countOfShots++;
            if (shipCoordinate.Contains(coordinate))
            {
                shipCoordinate.Remove(coordinate);
                return true;
            }
            return false;
        }

        private bool IsFieldEmpty()
        {
            if (shipCoordinate.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retern count of shots that had been already done.
        /// </summary>
        public int GetCountOfShots()
        {
            return countOfShots;
        }

        private List<string> GenerateShipsCoordinate()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder coordinate = new StringBuilder();
            for (int i = 0; i < numberOfShips; i++)
            {
                while (true)
                {
                    coordinate.Clear();
                    coordinate.Append((char)(ASCIICodeOfa + random.Next(0, fieldSize + 1)));
                    coordinate.Append((random.Next(0, fieldSize + 1)).ToString());

                    if (IsPossibleInTheMiddle(coordinate.ToString()))
                    {
                        shipCoordinate.Add(coordinate.ToString());
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return shipCoordinate;
        }

        private bool IsPossibleInTheMiddle(string coordinate)
        {
            // check elements near top side
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (shipCoordinate.Contains(String.Empty + (char)(coordinate[0] - 1 + y) + (char)(coordinate[1] - 1 + x)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
