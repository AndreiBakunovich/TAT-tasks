using System;

namespace List_Wednesday
{
    /// <summary>
    /// List.
    /// </summary>
    public class List<T>
    {
        private Node<T> head { get; set; }
        private int count;
        private Node<T> current;

        /// <summary>
        /// Set current position on start of list.
        /// </summary>
        public void SetCurrentOnHead()
        {
            current = head;
        }

        /// <summary>
        /// Return current value.
        /// </summary>
        /// <returns> Value of current position. </returns>
        public T GetCurrentValue()
        {
            return current.value;
        }

        /// <summary>
        /// Add value on start.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> result = new Node<T>();
            if (head == null)
            {
                head.value = value;
            }
            else
            {
                result.nextNode = head;
                this.head = result;
            }
            count++;
        }

        /// <summary>
        /// Remove first node with value.
        /// </summary>
        /// <param name="value"> Value of node to remove. </param>
        /// <returns> Is element was removed. </returns>
        public bool Remove(int value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.value.Equals(value) && head.nextNode == null)
            {
                head = null;
                count = 0;
                return true;
            }

            Node<T> node = head;
            do
            {
                if (node.value.Equals(value))
                {
                    head = head.nextNode;
                    count--;
                    break;
                }
            }
            while (node.nextNode != null);

            return false;
        }

        /// <summary>
        /// Returns last node in list or null if list empty.
        /// </summary>
        /// <returns> Link of last node in list. </returns>
        public Node<T> GetLast()
        {
            if (head == null)
            {
                return null;
            }

            Node<T> last = head.nextNode;
            while (last.nextNode != null)
            {
                last = last.nextNode;
            }
            return last;
        }

        /// <summary>
        /// Returns number of elements in list.
        /// </summary>
        /// <returns> Number of elements in list. </returns>
        public int Count()
        {
            return count;
        }
    }
}