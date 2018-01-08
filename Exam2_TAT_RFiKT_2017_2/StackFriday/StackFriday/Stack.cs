using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFriday
{
    /// <summary>
    /// Class stack.
    /// </summary>
    /// <typeparam name="T"> T is type of values in stack. </typeparam>
    public class Stack<T>
    {
        private Node<T> top;
        private int count { get; set; }

        /// <summary>
        /// Removes all objects from the Stack.
        /// </summary>
        public void Clear()
        {
            if (top == null)
            {
                return;
            }
            Node<T> next = top.nextNode;
            while (next != null)
            {
                top = null;
                top = next;
                next = next.nextNode;
            }
            count = 0;
        }

        /// <summary>
        /// Returns exception if stack empty.
        /// </summary>
        /// <returns> Returns value on the top. </returns>
        public T Peek()
        {
            if (!IsEmpty())
            {
                return top.value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Returns number of objects in stack.
        /// </summary>
        /// <returns> Returns number of objects in stack. </returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Returns exception if stack empty.
        /// </summary>
        /// <returns> Value of removing object. </returns>
        public T Pop()
        {
            if (!IsEmpty())
            {
                count--;
                Node<T> toRemove = top;
                top = top.nextNode;
                return toRemove.value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Add new element to stack.
        /// </summary>
        /// <param name="value"> New value of node to insert in stack. </param>
        public void Push(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.value = value;
            newNode.nextNode = top;
            top = newNode;
            count++;
        }

        /// <summary>
        /// Returns true if stack empty.
        /// </summary>
        /// <returns> Returns true if stack empty. </returns>
        public bool IsEmpty()
        {
            return top == null ? true : false;
        }
    }
}
