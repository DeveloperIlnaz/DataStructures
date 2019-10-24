using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public interface IQueue<T> : IEnumerable, IEnumerable<T>
    {
        T Peek();
        void Enqueue(T item);
        T Dequeue();
        void Clear();
        bool Contains(T item);
    }
}