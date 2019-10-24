using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Deque
{
    public interface IDeque<T> : IEnumerable, IEnumerable<T>
    {
        T PeekFirst();
        T PeekLast();
        void AddFirst(T item);
        void AddLast(T item);
        T RemoveFirst();
        T RemoveLast();
        void Clear();
        bool Contains(T item);
    }
}