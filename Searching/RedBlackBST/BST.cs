using System;
using System.Collections.Generic;
using System.Xml;

namespace RedBlackBST
{
    public class BST<TKey,TValue> where TKey: IComparable<TKey>
    {
        private Node root;

        private static readonly bool RED = true;
        private static readonly bool BLACK = false;

        private class Node
        {
            public TKey key;
            public TValue val;
            public Node left, right;
            public int N;
            public bool color; 

            public Node(TKey key, TValue val, int N, bool color)
            {
                this.key = key;
                this.val = val;
                this.N = N;
                this.color = color;
            }
        }

        private bool isRed(Node h)
        {
            if (h == null) return false;
            return h.color == RED;
        }

        public void RotateLeft()
        {
            root = rotateLeft(root);
        }

        public void RotateRight()
        {
            root = rotateRight(root);
        }

        private Node rotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + size(h.left)+ size(h.right);
            return x;
        }

        private Node rotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.color = h.color;
            h.color = RED;
            x.N = h.N;
            h.N = 1 + size(h.left)+ size(h.right);
            return x;
        }

        private void flipColors(Node h)
        {
            h.color = RED;
            h.left.color = BLACK;
            h.right.color = BLACK;
        }

        public int size()
        {
            return size(root);
        }
        private int size(Node x)
        {
            if (x == null) return 0;
            else return x.N;
        }

        public void put(TKey key, TValue val)
        {
            root = put(root, key, val);
            root.color = BLACK;
        }
        private Node put(Node h, TKey key, TValue val)
        {
            if (h == null) 
                return new Node(key, val, 1, RED);
            int cmp = key.CompareTo(h.key);
            if (cmp < 0) h.left = put(h.left, key, val);
            else if (cmp > 0) h.right = put(h.right, key, val);
            else h.val = val;
            if (isRed(h.right) && !isRed(h.left)) h = rotateLeft(h);
            if (isRed(h.left) && isRed(h.left.left)) h = rotateRight(h);
            if (isRed(h.left) && isRed(h.right)) flipColors(h);
            h.N = size(h.left) + size(h.right) + 1;
            return h;
        }

        public void print()
        {
            print(root);
        }
        private void print(Node x)
        {
            if (x == null) return;
            print(x.left);
            Console.WriteLine(x.val);
            print(x.right);
        }
    }
}