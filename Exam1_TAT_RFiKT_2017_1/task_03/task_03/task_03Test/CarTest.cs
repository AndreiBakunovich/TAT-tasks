using System;
using task_03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace task_03Test
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TestCompareToEqualCars()
        {
            Car carA = new Car();
            Car carB = new Car();
            carA.mark = "Volvo";
            carA.model="xc90";
            carA.type="sedan";
            carA.price=1000;

            carB.mark="Volvo";
            carB.model="xc90";
            carB.type="sedan";
            carB.price=1000;

            Assert.AreEqual(0 , carA.CompareTo(carB));
        }

        [TestMethod]
        public void TestCompareToEmptyCar()
        {
            Car carA = new Car();
            Car carB = new Car();
            carA.mark="Volvo";
            carA.model="xc90";
            carA.type="sedan";
            carA.price=1000;

            carB.mark=String.Empty;
            carB.model=String.Empty;
            carB.type=String.Empty;

            Assert.AreEqual(1 , carA.CompareTo(carB));
        }

        [TestMethod]
        public void TestCompareToEmptyCars()
        {
            Car carA = new Car();
            Car carB = new Car();
            carA.mark=String.Empty;
            carA.model=String.Empty;
            carA.type=String.Empty;

            carB.mark=String.Empty;
            carB.model=String.Empty;
            carB.type=String.Empty;

            Assert.AreEqual(0 , carA.CompareTo(carB));
        }

        [TestMethod]
        public void TestCompareToEqualCarsDifferentmodel()
        {
            Car carA = new Car();
            Car carB = new Car();
            carA.mark="Volvo";
            carA.model="xc90";
            carA.type="sedan";
            carA.price=1000;

            carB.mark="Volvo";
            carB.model="axc90";
            carB.type="sedan";
            carB.price=1000;

            Assert.AreEqual(0 , carA.CompareTo(carB));
        }

        [TestMethod]
        public void TestCompareToCarLessThanA()
        {
            Car carA = new Car();
            Car carB = new Car();
            carA.mark="BMV";
            carA.model="xc90";
            carA.type="sedan";
            carA.price=1000;

            carB.mark="Volvo";
            carB.model=+"axc90";
            carB.type="sedan";
            carB.price=1000;

            Assert.AreEqual(-1 , carA.CompareTo(carB));
        }

    }
}
