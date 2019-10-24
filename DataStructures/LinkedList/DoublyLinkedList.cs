using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable, IEnumerable<T>
    {
        private bool IsEmpty => Count == 0;

        public int Count { get; private set; }
        public DoublyLinkedListNode<T> First { get; private set; }
        public DoublyLinkedListNode<T> Last { get; private set; }

        public DoublyLinkedList()
        {

        }
        public DoublyLinkedList(ICollection<T> collection)
        {
            foreach (T value in collection)
            {
                AddLast(value);
            }
        }

        public DoublyLinkedListNode<T> AddFirst(T value)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                Last = node;
            }
            else
            {
                node.Next = First;
                First.Previous = node;
            }

            First = node;

            Count++;

            return node;
        }
        public DoublyLinkedListNode<T> AddLast(T value)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value);

            if (IsEmpty)
            {
                First = node;
            }
            else
            {
                node.Previous = Last;
                Last.Next = node;
            }

            Last = node;

            Count++;

            return node;
        }
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
        public bool Contains(T value)
        {
            DoublyLinkedListNode<T> current = First;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}