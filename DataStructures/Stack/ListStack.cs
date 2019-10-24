using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class ListStack<T> : IStack<T>, IEnumerable, IEnumerable<T>
    {
        private List<T> items;

        private bool IsEmpty => Count == 0;

        public int Count => items.Count;

        public ListStack()
        {
            items = new List<T>();
        }
        public ListStack(ICollection<T> collection)
        {
            items = collection.Reverse().ToList();
        }

        public void Push(T item)
        {
            items.Insert(0, item);
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

            items.RemoveAt(0);

            return item;
        }
        public void Clear()
        {
            items = new List<T>();
        }
        public bool Contains(T item)
        {
            return items.Any(i => i.Equals(item));
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