using System;
using System.Collections.Generic;
using System.Linq;

namespace Searching.ST
{
    public class SymbolTable<TKey,TValue> where TKey:IComparable<TKey>
    {
        private Dictionary<TKey, TValue> st;

        public SymbolTable()
        {
            st=new Dictionary<TKey, TValue>();
        }

        public void put(TKey key, TValue value)
        {
            st.Add(key,value);
        }

        public TValue get(TKey key)
        {
            TValue value = default(TValue);
            st.TryGetValue(key, out value);
            return value;
        }
        
        public void delete(TKey key)
        {
            st.Remove(key);
        }
        
        public bool contains(TKey key)
        {
            return st.ContainsKey(key);
        }
        
        public bool isEmpty()
        {
            return st.Count == 0;
        }
        
        public int size()
        {
            return st.Count;
        }
        
        public TKey min()
        {
            TKey min = st.First().Key;
            foreach (var pair in st.Where(pair => pair.Key.CompareTo(min) < 0))
            {
                min = pair.Key;
            }
            return min;
        }
        
        public TKey max()
        {
            TKey max = st.First().Key;
            foreach (var pair in st.Where(pair => pair.Key.CompareTo(max) > 0))
            {
                max = pair.Key;
            }
            return max;
        }
        
        public TKey floor(TKey key)
        {
            TKey find = min();
            foreach (var pair in st.Where(pair => pair.Key.CompareTo(find) > 0 && pair.Key.CompareTo(key) < 0))
            {
                find = pair.Key;
            }
            return find;
        }
        
        public TKey celling(TKey key)
        {
            TKey find = max();
            foreach (var pair in st.Where(pair => pair.Key.CompareTo(find) < 0 && pair.Key.CompareTo(key) >= 0))
            {
                find = pair.Key;
            }
            return find;
        }
        
        public int rank(TKey key)
        {
            return st.Keys.Count(k => k.CompareTo(key) < 0);
        }

        public TKey select(int rank)
        {
            int k = 0;
            TKey select=default(TKey);
            foreach (var pair in st.Where(pair => ++k == rank))
                @select = pair.Key;
            return select;
        }
        
        public void deleteMin()
        {
            delete(min());
        }
        
        public void deleteMax()
        {
            delete(max());
        }
        
        public int size(TKey lo, TKey hi)
        {
            return st.Count(k => k.Key.CompareTo(lo) >= 0 && k.Key.CompareTo(hi) <= 0);
        }
        
        public IEnumerable<TKey> keys(TKey lo, TKey hi)
        {
            return sorted().Keys.Where(i => i.CompareTo(lo) >= 0 && i.CompareTo(hi) <= 0);
        } 
        
        IEnumerable<TKey> keys()
        {
            return sorted().Keys;
        }

        private SortedDictionary<TKey,TValue> sorted()
        {
            return new SortedDictionary<TKey, TValue>(st);
        }

        public void Show()
        {
            Console.WriteLine("\n\tSymbol Table");
            Console.WriteLine("Key\tValue");
            foreach (var pair in st)
            {
                Console.WriteLine("{0}\t{1}",pair.Key,pair.Value);
            }
        }

        public void SortedShow()
        {
            Console.WriteLine("\n\tSorted Symbol Table");
            Console.WriteLine("Key\tValue");
            foreach (var pair in sorted())
            {
                Console.WriteLine("{0}\t{1}", pair.Key, pair.Value);
            }
        }

    }
}