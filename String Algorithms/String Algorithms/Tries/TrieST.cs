using System;
using System.Collections.Generic;

namespace String_Algorithms
{
    public class TrieST<Value>
    {
        private static int R = 256; // radix
        private Node root; // root of trie

        private class Node
        {
            public object val;
            public Node[] next = new Node[R];
        }

        public Value get(string key)
        {
            Node x = get(root, key, 0);
            if (x == null) return default(Value);
            return (Value)x.val;
        }

        private Node get(Node x, string key, int d)
        { // Return value associated with key in the subtrie rooted at x.
            if (x == null) return null;
            if (d == key.Length) return x;
            char c = key[d]; // Use dth key char to identify subtrie.
            return get(x.next[c], key, d + 1);
        }

        public void put(string key, Value val)
        {
            root = put(root, key, val, 0);
        }

        private Node put(Node x, string key, Value val, int d)
        { // Change value associated with key if in subtrie rooted at x.
            if (x == null) x = new Node();
            if (d == key.Length)
            {
                x.val = val;
                return x;
            }
            char c = key[d]; // Use dth key char to identify subtrie.
            x.next[c] = put(x.next[c], key, val, d + 1);
            return x;
        }

        private int search(Node x, string s, int d, int length)
        {
            if (x == null) return length;
            if (x.val != null) length = d;
            if (d == s.Length) return length;
            char c = s[d];
            return search(x.next[c], s, d + 1, length);
        }

        public string longestPrefixOf(string s)
        {
            int length = search(root, s, 0, 0);
            return s.Substring(0, length);
        }//the longest key that is a prefix of s

        public IEnumerable<string> keysWithPrefix(string s)
        {
            Queue<string> q = new Queue<string>();
            collect(get(root, s, 0), s, q);
            return q;
        }//all the keys having s as a prefi x

        public IEnumerable<string> keysThatMatch(string s)
        {
            Queue<string> q = new Queue<string>();
            collect(root, "", s, q);
            return q;
        } //all the keys that match s (where.matches any character)

        public int size()
        {
            return size(root);
        }//number of key-value pairs

        private int size(Node x)
        {
            if (x == null) return 0;
            int cnt = 0;
            if (x.val != null) cnt++;
            for (char c = (char) 0; c < R; c++)
                cnt += size(x.next[c]);
            return cnt;
        }

        public IEnumerable<string> keys()
        {
            return keysWithPrefix("");
        }//all the keys in the table

        private void collect(Node x, string pre, Queue<string> q)
        {
            if (x == null) return;
            if (x.val != null) q.Enqueue(pre);
            for (char c = (char) 0; c < R; c++)
                collect(x.next[c], pre + c, q);
        }

        private void collect(Node x, string pre, string pat, Queue<string> q)
        {
            int d = pre.Length;
            if (x == null) return;
            if (d == pat.Length && x.val != null) q.Enqueue(pre);
            if (d == pat.Length) return;
            char next = pat[d];
            for (char c = (char) 0; c < R; c++)
                if (next == '.' || next == c)
                    collect(x.next[c], pre + c, pat, q);
        }
    }
}
