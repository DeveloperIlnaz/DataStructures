using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Set
{
    public class ListSet<T> : IEnumerable, IEnumerable<T>
    {
        private List<T> items;

        public int Count => items.Count;

        public ListSet()
        {
            items = new List<T>();
        }
        public ListSet(ICollection<T> collection)
        {
            items = collection.ToList();
        }

        public bool Add(T item)
        {
            if (items.Contains(item))
            {
                return false;
            }

            items.Add(item);

            return true;
        }
        public bool Remove(T item)
        {
            if (!items.Contains(item))
            {
                return false;
            }

            items.Remove(item);

            return true;
        }
        public void Clear()
        {
            items = new List<T>();
        }
        public void UnionWith(IEnumerable<T> other)
        {
            items = items.Union(other).ToList();
        }
        public void IntersectWith(IEnumerable<T> other)
        {
            items = items.Intersect(other).ToList();
        }
        public void ExceptWith(IEnumerable<T> other)
        {
            items = items.Except(other).ToList();
        }
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            items = items.Except(other).Union(other.Except(items)).ToList();
        }
        public bool Contains(T item)
        {
            if (items.Contains(item))
            {
                return true;
            }

            return false;
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