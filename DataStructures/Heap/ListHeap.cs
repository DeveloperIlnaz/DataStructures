using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Heap
{
    public class ListHeap<T> where T : IComparable
    {
        private List<T> items;

        public T First => items[0];
        public int Count => items.Count;

        public ListHeap()
        {
            items = new List<T>();
        }
        public ListHeap(ICollection<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        private void SortItems(int index)
        {
            int maxIndex = index;
            int leftIndex;
            int rightIndex;

            while (index < Count)
            {
                leftIndex = 2 * index + 1;
                rightIndex = 2 * index + 2;

                if (leftIndex < Count && items[leftIndex].CompareTo(items[maxIndex]) == 1)
                {
                    maxIndex = leftIndex;
                }

                if (rightIndex < Count && items[rightIndex].CompareTo(items[maxIndex]) == 1)
                {
                    maxIndex = rightIndex;
                }

                if (maxIndex == index)
                {
                    break;
                }

                SwapItem(index, maxIndex);
                index = maxIndex;
            }
        }
        private void SwapItem(int firstItemIndex, int secondItemIndex)
        {
            var temp = items[firstItemIndex];
            items[firstItemIndex] = items[secondItemIndex];
            items[secondItemIndex] = temp;
        }
        private int GetLastIndex()
        {
            return Count - 1;
        }
        private int GetRootIndex(int index)
        {
            return (index - 1) / 2;
        }

        public void Add(T item)
        {
            items.Add(item);

            var lastIndex = GetLastIndex();
            var rootIndex = GetRootIndex(lastIndex);

            while (items[lastIndex].CompareTo(items[rootIndex]) == 1)
            {
                SwapItem(lastIndex, rootIndex);

                lastIndex = rootIndex;
                rootIndex = GetRootIndex(lastIndex);
            }
        }
        public void RemoveFirst()
        {
            var lastIndex = GetLastIndex();

            items[0] = items[lastIndex];
            items.RemoveAt(lastIndex);

            SortItems(0);
        }
        public IEnumerator GetEnumerator()
        {
            return items.OrderByDescending(i => i).GetEnumerator();
        }
    }
}