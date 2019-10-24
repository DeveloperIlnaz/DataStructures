using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ArrayStack<T> : IStack<T>, IEnumerable, IEnumerable<T>
    {
        private T[] items;

        private bool IsEmpty => Count == 0;
        private bool IsOverflow => Count == items.Length;

        public int Count { get; private set; }

        public ArrayStack(int capacity)
        {
            items = new T[capacity];
        }
        public ArrayStack(ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public void Push(T item)
        {
            if (IsOverflow)
            {
                throw new StackOverflowException("Стек переполнен.");
            }

            items = items.Prepend(item).Take(items.Length).ToArray();

            Count++;
        }
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            return items[0];
        }
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Стек пуст.");
            }

            var item = items[0];

            items = items.Skip(1).Select(i => i).Append(default).ToArray();

            Count--;

            return item;
        }
        public void Clear()
        {
            items = new T[items.Length];
            Count = 0;
        }
        public bool Contains(T item)
        {
            return items.Take(Count).Any(i => i.Equals(item));
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.Take(Count).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}