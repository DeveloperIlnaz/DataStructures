using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Dictionary
{
    public class HashDictionary<TKey, TValue> : IEnumerable, IEnumerable<DictionaryItem<TKey, TValue>>
    {
        private readonly int capacity = 128;

        private int[] itemIndices;

        private DictionaryItem<TKey, TValue>[] items;

        public TValue this[TKey key]
        {
            get
            {
                int hashCode = GetHash(key);

                int index = itemIndices[hashCode];

                DictionaryItem<TKey, TValue> item = items[index];

                if (!item.Value.Equals(key))
                {
                    throw new KeyNotFoundException("Данный ключ отсутствует в словаре.");
                }

                return item.Value;
            }
        }

        public int Count { get; private set; }

        public HashDictionary()
        {
            itemIndices = new int[capacity];
            items = new DictionaryItem<TKey, TValue>[capacity];
        }
        public HashDictionary(ICollection<DictionaryItem<TKey, TValue>> collection)
        {
            itemIndices = new int[collection.Count];
            items = collection.ToArray();

            Count += collection.Count;
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % capacity;
        }
        public void Add(TKey key, TValue value)
        {
            int hashCode = GetHash(key);

            DictionaryItem<TKey, TValue> item = new DictionaryItem<TKey, TValue>(key, value);

            itemIndices[hashCode] = Count;

            items[Count] = new DictionaryItem<TKey, TValue>(key, value);

            Count++;
        }
        public void Remove(TKey key)
        {
            int hashCode = GetHash(key);

            int index = itemIndices[hashCode];

            itemIndices[hashCode] = default;

            itemIndices = itemIndices.Select(new Func<int, int>((x) => x != 0 ? x - 1 : 0)).ToArray();

            items = items.Where(i => i != items[index]).Append(default).ToArray();

            Count--;
        }
        public bool ContainsKey(TKey key)
        {
            int hashCode = GetHash(key);

            int index = itemIndices[hashCode];

            if (items[index].Equals(key))
            {
                return true;
            }

            return false;
        }
        public void Clear()
        {
            itemIndices = new int[capacity];
            items = new DictionaryItem<TKey, TValue>[capacity];
        }
        public IEnumerator<DictionaryItem<TKey, TValue>> GetEnumerator()
        {
            return items.Take(Count).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
