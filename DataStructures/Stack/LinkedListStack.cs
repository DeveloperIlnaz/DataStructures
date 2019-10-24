using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.LinkedList;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>, IEnumerable, IEnumerable<T>
    {
        private SinglyLinkedListNode<T> first;

        private bool IsEmpty => Count == 0;

        public int Count { get; private set; }

        public LinkedListStack()
        {

        }
        public LinkedListStack(ICollection<T> collection)
        {
            foreach (T item in collection)
            {
                Push(item);
            }
        }

        public void Push(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);

            if (first != null)
            {
                node.Next = first;
            }

            first = node;

            Count++;
        }
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            return first.Value;
        }
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            var node = first.Value;

            first = first.Next;

            Count--;

            return node;
        }
        public void Clear()
        {
            first = null;
            Count = 0;
        }
        public bool Contains(T item)
        {
            var node = first;

            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var node = first;

            while (node != null)
            {
                yield return node.Value;

                node = node.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}