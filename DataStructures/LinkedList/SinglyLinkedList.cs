using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class SinglyLinkedList<T> : IEnumerable, IEnumerable<T>
    {
        public int Count { get; private set; }
        public SinglyLinkedListNode<T> First { get; private set; }
        public SinglyLinkedListNode<T> Last { get; private set; }

        public SinglyLinkedList()
        {

        }
        public SinglyLinkedList(ICollection<T> collection)
        {
            foreach (T value in collection)
            {
                AddLast(value);
            }
        }

        public SinglyLinkedListNode<T> AddFirst(T value)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(value);

            if (Count < 1)
            {
                Last = node;
            }
            else
            {
                node.Next = First;
            }

            First = node;

            Count++;

            return node;
        }
        public SinglyLinkedListNode<T> AddLast(T value)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(value);

            if (Count < 1)
            {
                First = node;
            }
            else
            {
                Last.Next = node;
            }

            Last = node;

            Count++;

            return node;
        }
        public void RemoveFirst()
        {
            if (Count < 1)
            {
                throw new InvalidOperationException("SinglyLinkedList пуст.");
            }

            First = First.Next;

            Count--;
        }
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
        public bool Contains(T value)
        {
            SinglyLinkedListNode<T> current = First;

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
            SinglyLinkedListNode<T> current = First;

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