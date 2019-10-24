using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class ListQueue<T> : IQueue<T>, IEnumerable, IEnumerable<T>
    {
        private List<T> items;

        private bool IsEmpty => Count == 0;

        public int Count => items.Count;

        public ListQueue()
        {
            items = new List<T>();
        }
        public ListQueue(ICollection<T> collection)
        {
            items = collection.ToList();
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
            items.Add(item);
        }
        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Очередь пуст.");
            }

            T item = items[0];
            items.RemoveAt(0);
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