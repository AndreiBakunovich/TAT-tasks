namespace StackFriday
{
    /// <summary>
    /// Class node for list.
    /// </summary>
    public class Node<T>
    {
        /// <summary>
        /// Informatio value.
        /// </summary>
        public T value { get; set; }
        /// <summary>
        /// Link for the next node.
        /// </summary>
        public Node<T> nextNode { get; set; }
    }
}
