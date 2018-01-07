namespace List_Wednesday
{
    /// <summary>
    /// Node for linked list.
    /// </summary>
    public class LinkedNode<T>
    {
        /// <summary>
        /// Information value.
        /// </summary>
        public T value { get; set; }
        /// <summary>
        /// Link for the previouse node.
        /// </summary>
        public LinkedNode<T> prevNode { get; set; }
        /// <summary>
        /// Link for the next node.
        /// </summary>
        public LinkedNode<T> nextNode { get; set; }
    }
}