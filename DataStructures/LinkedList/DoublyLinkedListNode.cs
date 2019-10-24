namespace DataStructures.LinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public T Value { get; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}