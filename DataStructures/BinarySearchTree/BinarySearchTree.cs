using System;
using System.Collections.Generic;

namespace DataStructures.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTreeNode<T> Root { get; private set; }
        public int Count { get; private set; }

        private IEnumerable<T> Preorder(BinarySearchTreeNode<T> node)
        {
            var nodes = new List<T>();

            if (node != null)
            {
                nodes.Add(node.Value);

                if (node.Left != null)
                {
                    nodes.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    nodes.AddRange(Preorder(node.Right));
                }
            }

            return nodes;
        }
        private IEnumerable<T> Postorder(BinarySearchTreeNode<T> node)
        {
            var nodes = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    nodes.AddRange(Postorder(node.Left));
                }

                if (node.Right != null)
                {
                    nodes.AddRange(Postorder(node.Right));
                }

                nodes.Add(node.Value);
            }

            return nodes;
        }
        private IEnumerable<T> Inorder(BinarySearchTreeNode<T> node)
        {
            var nodes = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    nodes.AddRange(Inorder(node.Left));
                }

                nodes.Add(node.Value);

                if (node.Right != null)
                {
                    nodes.AddRange(Inorder(node.Right));
                }
            }

            return nodes;
        }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(value);
            }
            else
            {
                Root.Add(value);
            }

            Count++;
        }
        public IEnumerable<T> Preorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }
            
            return Preorder(Root);
        }
        public IEnumerable<T> Postorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Postorder(Root);
        }
        public IEnumerable<T> Inorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Inorder(Root);
        }
    }
}