using System;

namespace Sorts
{
    public static class Insertion
    {
        public static void Sort(IComparable[] a)
        {
            // Sort a[] into increasing order.
            int N = a.Length;
            for (int i = 1; i < N; i++)
            { // Insert a[i] among a[i-1], a[i-2], a[i-3]... ..
                for (int j = i; j > 0 && a[j].CompareTo(a[j - 1])==-1; j--)
                    Helpers.exch(a, j, j - 1);
            }
        }
    }
}