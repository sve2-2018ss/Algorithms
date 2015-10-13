using System;

namespace Sorts
{
    public class Quick3Way
    {
        public static void Sort(IComparable[] a)
        {
            Helpers.shuffle(a); // Eliminate dependence on input.
            sort(a, 0, a.Length - 1);
        }

        public static void sort(IComparable[] a, int lo, int hi)
        {
            
            if (hi <= lo) return;
            int lt = lo, i = lo + 1, gt = hi;
            IComparable v = a[lo];
            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) Helpers.exch(a, lt++, i++);
                else if (cmp > 0) Helpers.exch(a, i, gt--);
                else i++;
            } // Now a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi].
            sort(a, lo, lt - 1);
            sort(a, gt + 1, hi);
        }
    }
}