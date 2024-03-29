﻿namespace DataStructures.Dictionary
{
    public class DictionaryItem<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public DictionaryItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
        public override string ToString()
        {
            return $"[{Key}, {Value}]";
        }
    }
}