using System;
using System.ComponentModel;
using System.Threading;

namespace Sorts
{
    public class Quick
    {
        public void Sort(IComparable[] a)
        {
            Helpers.shuffle(a); // Eliminate dependence on input.
            sort(a, 0, a.Length - 1);
        }
        
        protected virtual void sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = partition(a, lo, hi);
            sort(a, lo, j - 1); // Sort left part a[lo .. j-1].
            sort(a, j + 1, hi); // Sort right part a[j+1 .. hi].
        }

        protected virtual int partition(IComparable[] a, int lo, int hi)
        { // Partition into a[lo..i-1], a[i], a[i+1..hi].
            int i = lo, j = hi + 1; // left and right scan indices
            IComparable v = a[lo]; // partitioning item
            while (true)
            { // Scan right, scan left, check for scan complete, and exchange.
                while (a[++i].CompareTo(v)==-1) if (i == hi) break;
                while (v.CompareTo(a[--j])==-1) if (j == lo) break;
                if (i >= j) break;
                Helpers.exch(a, i, j);
            }
            Helpers.exch(a, lo, j); // Put v = a[j] into position
            return j; // with a[lo..j-1] <= a[j] <= a[j+1..hi].
        }
    }
}