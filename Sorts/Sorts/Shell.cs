using System;

namespace Sorts
{
    public class Shell
    {
        public static void Sort(IComparable[] a)
        {
            // Sort a[] into increasing order.
            int N = a.Length;
            int h = 1;
            while (h < N/3) h = 3*h + 1; // 1, 4, 13, 40, 121, 364, 1093, ...
            while (h >= 1)
            {
                // h-sort the array.
                for (int i = h; i < N; i++)
                {
                    // Insert a[i] among a[i-h], a[i-2*h], a[i-3*h]... .
                    for (int j = i; j >= h && a[j].CompareTo(a[j - h]) == -1; j -= h)
                        Helpers.exch(a, j, j - h);
                }
                h = h/3;
            }
        }
    }
}