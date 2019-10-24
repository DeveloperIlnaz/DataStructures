using System;

namespace DataStructures.BinarySearchTree
{
    public class BinarySearchTreeNode<T> where T : IComparable<T>
    {
        public T Value { get; private set; }
        public BinarySearchTreeNode<T> Left { get; private set; }
        public BinarySearchTreeNode<T> Right { get; private set; }

        public BinarySearchTreeNode(T value)
        {
            Value = value;
        }

        public void Add(T value)
        {
            var node = new BinarySearchTreeNode<T>(value);

            if (node.Value.CompareTo(Value) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(value);
                }
            }
        }
        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}