using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackFriday;

namespace StackFridayTest
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void TestPush10Elements()
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i.ToString());
            }
            Assert.AreEqual(10, stack.Count());
        }

        [TestMethod]
        public void TestClear()
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i.ToString());
            }
            stack.Clear();
            Assert.AreEqual(0, stack.Count());
        }

        [TestMethod]
        public void TestClearEmptyStack()
        {
            Stack<string> stack = new Stack<string>();

            stack.Clear();
            Assert.AreEqual(0, stack.Count());
        }

        [TestMethod]
        public void TestPopByCountLastElement()
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i.ToString());
            }
            stack.Pop();
            Assert.AreEqual(9, stack.Count());
        }

        [TestMethod]
        public void TestPopByPeekLastElement()
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i.ToString());
            }
            stack.Pop();
            Assert.AreEqual("8", stack.Peek());
        }

        [TestMethod]
        public void TestPeekWithEmptyStack()
        {
            Stack<string> stack = new Stack<string>();
            Assert.AreEqual(new NullReferenceException(), stack.Peek());
        }

        [TestMethod]
        public void TestPopWithEmptyStack()
        {
            Stack<string> stack = new Stack<string>();
            Assert.AreEqual(new NullReferenceException(), stack.Pop());
        }


    }
}
