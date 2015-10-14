using System;
using System.Collections.Generic;
using System.Xml;

namespace Binary_Search_Trees
{
    public class BST<TKey,TValue> where TKey: IComparable<TKey>
    {
        private Node root;

        private class Node
        {
            public TKey key;
            public TValue value;
            public Node left, right;
            public int N;

            public Node(TKey key, TValue val, int N)
            {
                this.key = key;
                this.value = val;
                this.N = N;
            }
        }

        public int size()
        { return size(root); }

        private int size(Node x)
        {
            if (x == null) return 0;
            else return x.N;
        }

        public TValue get(TKey key)
        {
            return get(root, key);
        }
        private TValue get(Node x, TKey key)
        { 
            if (x == null) return default(TValue);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return get(x.left, key);
            else if (cmp > 0) return get(x.right, key);
            else return x.value;
        }

        public void put(TKey key, TValue val)
        { 
            root = put(root, key, val);
        }
        private Node put(Node x, TKey key, TValue val)
        {
            if (x == null) return new Node(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = put(x.left, key, val);
            else if (cmp > 0) x.right = put(x.right, key, val);
            else x.value = val;
            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public TKey min()
        {
            return min(root).key;
        }
        private Node min(Node x)
        {
            if (x.left == null) return x;
            return min(x.left);
        }

        public TKey floor(TKey key)
        {
            Node x = floor(root, key);
            if (x == null) return default(TKey);
            return x.key;
        }
        private Node floor(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return floor(x.left, key);
            Node t = floor(x.right, key);
            if (t != null) return t;
            else return x;
        }

        public TKey select(int k)
        {
            return select(root, k).key;
        }

        private Node select(Node x, int k)
        { 
            if (x == null) return null;
            int t = size(x.left);
            if (t > k) return select(x.left, k);
            else if (t < k) return select(x.right, k - t - 1);
            else return x;
        }

        public int rank(TKey key)
        {
            return rank(key, root);
        }
        private int rank(TKey key, Node x)
        { 
            if (x == null) return 0;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) return rank(key, x.left);
            else if (cmp > 0) return 1 + size(x.left) + rank(key, x.right);
            else return size(x.left);
        }

        public void deleteMin()
        {
            root = deleteMin(root);
        }
        private Node deleteMin(Node x)
        {
            if (x.left == null) return x.right;
            x.left = deleteMin(x.left);
            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public void delete(TKey key)
        {
            root = delete(root, key);
        }
        private Node delete(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp < 0) x.left = delete(x.left, key);
            else if (cmp > 0) x.right = delete(x.right, key);
            else
            {
                if (x.right == null) return x.left;
                if (x.left == null) return x.right;
                Node t = x;
                x = min(t.right); 
                x.right = deleteMin(t.right);
                x.left = t.left;
            }
            x.N = size(x.left) + size(x.right) + 1;
            return x;
        }

        public TKey max()
        {
            return max(root).key;
        }
        private Node max(Node x)
        {
            if (x.right == null) return x;
            return max(x.right);
        }

        public IEnumerable<TKey> keys()
        {
            return keys(min(), max());
        }
        public IEnumerable<TKey> keys(TKey lo, TKey hi)
        {
            Queue<TKey> queue = new Queue<TKey>();
            keys(root, queue, lo, hi);
            return queue;
        }
        private void keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.key);
            int cmphi = hi.CompareTo(x.key);
            if (cmplo < 0) keys(x.left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.key);
            if (cmphi > 0) keys(x.right, queue, lo, hi);
        }
        
        public void print()
        {
            print(root);
        }
        private void print(Node x)
        {
            if (x == null) return;
            print(x.left);
            Console.WriteLine(x.value);
            print(x.right);
        }
    }
}