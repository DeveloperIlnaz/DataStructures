using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Deque
{
    public class ArrayDeque<T> : IDeque<T>, IEnumerable, IEnumerable<T>
    {
        private T[] items;

        private bool IsEmpty => Count == 0;
        private bool IsOverflow => Count == items.Length;

        public int Count { get; private set; }

        public ArrayDeque(int capacity)
        {
            items = new T[capacity];
        }
        public ArrayDeque(ICollection<T> collection)
        {
            items = collection.ToArray();
            Count += items.Length;
        }

        public T PeekFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуст.");
            }

            return items[0];
        }
        public T PeekLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуст.");
            }

            return items[Count - 1];
        }
        public void AddFirst(T item)
        {
            if (IsOverflow)
            {
                throw new OverflowException("Дек переполнена.");
            }

            items = items.Prepend(item).Take(items.Length).ToArray();

            Count++;
        }
        public void AddLast(T item)
        {
            if (IsOverflow)
            {
                throw new OverflowException("Дек переполнена.");
            }

            items[Count] = item;

            Count++;
        }
        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуста.");
            }

            T item = items[0];

            items = items.Skip(1).Select(i => i).Append(default).ToArray();

            Count--;

            return item;
        }
        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуста.");
            }

            T item = items[Count - 1];

            items[Count - 1] = default;

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