using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Deque
{
    public class ListDeque<T> : IDeque<T>, IEnumerable, IEnumerable<T>
    {
        private List<T> items;

        private bool IsEmpty => Count == 0;

        public int Count => items.Count;

        public ListDeque()
        {
            items = new List<T>();
        }
        public ListDeque(ICollection<T> collection)
        {
            items = collection.ToList();
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

            return items[items.Count - 1];
        }
        public void AddFirst(T item)
        {
            items.Insert(0, item);
        }
        public void AddLast(T item)
        {
            items.Add(item);
        }
        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуст.");
            }

            T item = items[0];
            items.RemoveAt(0);
            return item;
        }
        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Дек пуст.");
            }

            T item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return item;
        }
        public void Clear()
        {
            items = new List<T>();
        }
        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}