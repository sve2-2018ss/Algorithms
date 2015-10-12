using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public static class Selection
    {
        public static void Sort(IComparable[] a)
        { // Sort a[] into increasing order.
            int N = a.Length; // array length
            for (int i = 0; i < N; i++)
            { // Exchange a[i] with smallest entry in a[i+1...N).
                int min = i; // index of minimal entr.
                for (int j = i + 1; j < N; j++)
                    if (a[j].CompareTo(a[min])==-1) min = j;
                Helpers.exch(a, i, min); 
            }
        }
    }
}
