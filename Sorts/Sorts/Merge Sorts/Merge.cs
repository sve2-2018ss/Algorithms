using System;

namespace Sorts
{
    public class Merge
    {
        private static IComparable[] aux; // auxiliary array for merges

        public void TopDownSort(IComparable[] a)
        {
            aux = new IComparable[a.Length]; // Allocate space just once.
            sort(a, 0, a.Length - 1);
        }

        protected virtual void sort(IComparable[] a, int lo, int hi)
        { // Sort a[lo..hi].
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, lo, mid); // Sort left half.
            sort(a, mid + 1, hi); // Sort right half.
            merge(a, lo, mid, hi); // Merge results (code on page 271).
        }

        public void BottomUpSort(IComparable[] a)
        { // Do lg N passes of pairwise merges.
            int N = a.Length;
            aux = new IComparable[N];
            for (int sz = 1; sz < N; sz = sz + sz) // sz: subarray size
                for (int lo = 0; lo < N - sz; lo += sz + sz) // lo: subarray index
                    merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
        }

        protected virtual void merge(IComparable[] a, int lo, int mid, int hi)
        { // Merge a[lo..mid] with a[mid+1..hi].
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++) // Copy a[lo..hi] to aux[lo..hi].
                aux[k] = a[k];
            for (int k = lo; k <= hi; k++) // Merge back to a[lo..hi].
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (aux[j].CompareTo(aux[i])==-1) a[k] = aux[j++];
                else a[k] = aux[i++];
        }
    }
}