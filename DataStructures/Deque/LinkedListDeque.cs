using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.LinkedList;

namespace DataStructures.Deque
{
    public class LinkedListDeque<T> : IDeque<T>, IEnumerable, IEnumerable<T>
    {
        private DoublyLinkedListNode<T> First { get; set; }
        private DoublyLinkedListNode<T> Last { get; set; }

        private bool IsEmpty => Count == 0;

        public int Count { get; private set; }

        public LinkedListDeque()
        {

        }
        public LinkedListDeque(ICollection<T> collection)
        {
            foreach (T item in collection)
            {
                AddLast(item);
            }
        }

        public T PeekFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуста.");
            }

            return First.Value;
        }
        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуста.");
            }

            return Last.Value;
        }
        public void AddFirst(T item)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(item);

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
        }
        public void AddLast(T item)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(item);

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
        }
        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуста.");
            }

            T node = First.Value;

            First = First.Next;

            // TODO: [LinkedLisqDeque] RemoveFirst (Previouse).

            Count--;

            return node;
        }
        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуста.");
            }

            T node = Last.Value;

            // TODO: [LinkedLisqDeque] RemoveLast (implement).

            return node;
        }
        public void Clear()
        {
            First = null;
            Last = null;
            Count = 0;
        }
        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = First;

            while (current != null)
            {
                if (current.Value.Equals(item))
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