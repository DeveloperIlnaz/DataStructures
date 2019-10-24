namespace DataStructures.LinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public T Value { get; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}