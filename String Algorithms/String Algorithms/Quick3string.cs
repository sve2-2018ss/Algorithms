using System;

namespace String_Algorithms
{
    public class Quick3string
    {
        private static int charAt(string s, int d)
        {
            if (d < s.Length)
                return s[d];
            else return -1;
        }

        public static void sort(string[] a)
        {
            sort(a, 0, a.Length - 1, 0);
        }

        private static void sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo) return;
            int lt = lo, gt = hi;
            int v = charAt(a[lo], d);
            int i = lo + 1;
            while (i <= gt)
            {
                int t = charAt(a[i], d);
                if (t < v) exch(a, lt++, i++);
                else if (t > v) exch(a, i, gt--);
                else i++;
            }
            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]
            sort(a, lo, lt - 1, d);
            if (v >= 0) sort(a, lt, gt, d + 1);
            sort(a, gt + 1, hi, d);
        }

        private static void exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}