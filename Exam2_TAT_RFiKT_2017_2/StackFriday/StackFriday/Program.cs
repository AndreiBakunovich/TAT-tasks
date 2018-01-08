using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFriday
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < 10 ; i++)
            {
                stack.Push(i.ToString());
            }

            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
