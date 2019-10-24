using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public interface IStack<T> : IEnumerable, IEnumerable<T>
    {
        void Push(T item);
        T Peek();
        T Pop();
        void Clear();
        bool Contains(T item);
    }
}