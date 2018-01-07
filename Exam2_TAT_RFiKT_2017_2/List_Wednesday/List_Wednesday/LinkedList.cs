namespace List_Wednesday
{
    /// <summary>
    /// Linked list.
    /// </summary>
    public class LinkedList<T>
    {
        private int count;
        public LinkedNode<T> head;

        /// <summary>
        /// Add value on start.
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Head node. </returns>
        public LinkedNode<T> Add(T value)
        {
            LinkedNode<T> result = new LinkedNode<T>();
            if (head == null)
            {
                head.value = value;
            }
            else
            {
                result.nextNode = head;
                head.prevNode = result;
                this.head = result;
            }

            count++;
            return result;
        }


        /// <summary>
        /// Remove first node with value.
        /// </summary>
        /// <param name="value"> Value of node to remove. </param>
        /// <returns> Is element was removed. </returns>
        public bool Remove(T value)
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

            LinkedNode<T> node = head;
            do
            {
                if (node.value.Equals(value))
                {
                    if (node == head)
                    {
                        head.nextNode.prevNode = null;
                        head = head.nextNode;
                        count--;
                        break;
                    }
                    else
                    {
                        node.nextNode.prevNode = node.prevNode;
                        node.prevNode.nextNode = node.nextNode;
                        count--;
                        break;
                    }
                }
            }
            while (node.nextNode != null);

            return false;
        }

        /// <summary>
        /// Returns last node in list or null if list empty.
        /// </summary>
        /// <returns> Link of last node in list. </returns>
        public LinkedNode<T> GetLast()
        {
            if (head == null)
            {
                return null;
            }

            LinkedNode<T> last = head.nextNode;
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