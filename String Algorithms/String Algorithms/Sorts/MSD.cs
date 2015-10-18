using System;

namespace String_Algorithms
{
    public class MSD
    {
        private static int R = 256; // radix
        private static readonly int M = 15; // cutoff for small subarrays
        private static string[] aux; // auxiliary array for distribution

        private static int charAt(String s, int d)
        {
            if (d < s.Length)
                return s[d];
            else return -1;
        }
        public static void sort(String[] a)
        {
            int N = a.Length;
            aux = new String[N];
            sort(a, 0, N - 1, 0);
        }
        private static void sort(String[] a, int lo, int hi, int d)
        { // Sort from a[lo] to a[hi], starting at the dth character.
            if (hi <= lo + M)
            {
                Insertion.sort(a, lo, hi, d);
                return;
            }
            int[] count = new int[R + 2]; // Compute frequency counts.
            for (int i = lo; i <= hi; i++)
                count[charAt(a[i], d) + 2]++;
            for (int r = 0; r < R + 1; r++) // Transform counts to indices.
                count[r + 1] += count[r];
            for (int i = lo; i <= hi; i++) // Distribute.
                aux[count[charAt(a[i], d) + 1]++] = a[i];
            for (int i = lo; i <= hi; i++) // Copy back.
                a[i] = aux[i - lo];
            // Recursively sort for each character value.
            for (int r = 0; r < R; r++)
                sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }
    }

    public static class Insertion
    {
        public static void sort(String[] a, int lo, int hi, int d)
        { // Sort from a[lo] to a[hi], starting at the dth character.
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && less(a[j], a[j - 1], d); j--)
                    exch(a, j, j - 1);
        }

        private static bool less(String v, String w, int d)
        {
            return v.Substring(d).CompareTo(w.Substring(d)) < 0;
        }

        private static void exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}