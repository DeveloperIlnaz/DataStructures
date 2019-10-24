using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class ArrayQueue<T> : IQueue<T>, IEnumerable, IEnumerable<T>
    {
        private T[] items;

        private bool IsEmpty => Count == 0;
        private bool IsOverflow => Count == items.Length;

        public int Count { get; private set; }

        public ArrayQueue(int capacity)
        {
            items = new T[capacity];
        }
        public ArrayQueue(ICollection<T> collection)
        {
            items = collection.ToArray();
            Count += items.Length;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуст.");
            }

            return items[0];
        }
        public void Enqueue(T item)
        {
            if (IsOverflow)
            {
                throw new OverflowException("Очередь переполнена.");
            }

            items[Count] = item;

            Count++;
        }
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуста.");
            }

            T item = items[0];

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