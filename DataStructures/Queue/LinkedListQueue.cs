using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.LinkedList;

namespace DataStructures.Queue
{
    public class LinkedListQueue<T> : IQueue<T>, IEnumerable, IEnumerable<T>
    {
        private SinglyLinkedListNode<T> First { get; set; }
        private SinglyLinkedListNode<T> Last { get; set; }

        private bool IsEmpty => Count == 0;

        public int Count { get; private set; }

        public LinkedListQueue()
        {

        }
        public LinkedListQueue(ICollection<T> collection)
        {
            foreach (T item in collection)
            {
                Enqueue(item);
            }
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            return First.Value;
        }
        public void Enqueue(T item)
        {
            SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(item);

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
        }
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            T node = First.Value;

            First = First.Next;

            Count--;

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
            SinglyLinkedListNode<T> current = First;

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