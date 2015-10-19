using System;

namespace Context
{
    public class SuffixArray
    {
        private readonly string[] suffixes; // suffix array
        private readonly int N; // length of string (and array)
        public SuffixArray(string s)
        {
            N = s.Length;
            suffixes = new string[N];
            for (int i = 0; i < N; i++)
                suffixes[i] = s.Substring(i);
            Quick3Way.Sort(suffixes);
        }

        public int length()
        {
            return N;
        }

        public string select(int i)
        {
            return suffixes[i];
        }

        public int index(int i)
        {
            return N - suffixes[i].Length;
        }

        private static int lcp(string s, string t)
        {
            int N = Math.Min(s.Length, t.Length);
            for (int i = 0; i < N; i++)
                if (s[i] != t[i])
                    return i;
            return N;
        }

        public int lcp(int i)
        {
            return lcp(suffixes[i], suffixes[i - 1]);
        }

        public int rank(string key)
        { // binary search
            int lo = 0, hi = N - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(suffixes[mid]);
                if (cmp < 0) hi = mid - 1;
                else if (cmp > 0) lo = mid + 1;
                else return mid;
            }
            return lo;
        }
    }
}