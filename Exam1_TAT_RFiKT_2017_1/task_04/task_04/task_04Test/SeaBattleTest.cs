using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task_04;

namespace task_04Test
{
    public class FakeConsoleReader : INextShot
    {
        private int number;

        public string GetNextShot()
        {
            string result = (char)((number - number % 10) / 10 + 97) + (number % 10).ToString();
            number++;
            return result;
        }
    }

    [TestClass]
    public class SeaBattleTest
    {
        [TestMethod]
        public void TestGetCountOfShotsOnTheStart()
        {
            Assert.AreEqual(0, new SeaBattle(new FakeConsoleReader()).GetCountOfShots());
        }

        [TestMethod]
        public void TestGetCountOfShotsOnTheEnd()
        {
            INextShot stubConsoleReader = new FakeConsoleReader();
            SeaBattle seaBattle = new SeaBattle(stubConsoleReader);
            seaBattle.StartBattle();
            Assert.IsTrue(seaBattle.GetCountOfShots() <= 100);
        }

        [TestMethod]
        public void TestGetCountOfShips()
        {
            INextShot stubConsoleReader = new FakeConsoleReader();
            SeaBattle seaBattle = new SeaBattle(stubConsoleReader);
            Assert.IsTrue(seaBattle.GetNumberOfShipsOnStart() <= 17);
        }

        [TestMethod]
        public void TestGetCountOfShipsOnTheEnd()
        {
            INextShot stubConsoleReader = new FakeConsoleReader();
            SeaBattle seaBattle = new SeaBattle(stubConsoleReader);
            seaBattle.StartBattle();
            Assert.IsTrue(seaBattle.GetNumberOfShipsOnStart() <= 17);
        }

        [TestMethod]
        public void TestSeaBattleCompareCountOfShipsAndShots()
        {
            INextShot stubConsoleReader = new FakeConsoleReader();
            SeaBattle seaBattle = new SeaBattle(stubConsoleReader);
            seaBattle.StartBattle();
            Assert.IsTrue(seaBattle.GetNumberOfShipsOnStart() < seaBattle.GetCountOfShots());
        }
    }
}
