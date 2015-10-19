using System;

namespace Context
{
    public static class Quick3Way
    {
        public static void Sort(IComparable[] a)
        {
            shuffle(a); // Eliminate dependence on input.
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
                if (cmp < 0) exch(a, lt++, i++);
                else if (cmp > 0) exch(a, i, gt--);
                else i++;
            } // Now a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi].
            sort(a, lo, lt - 1);
            sort(a, gt + 1, hi);
        }

        private static void shuffle(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int r = i + uniform(N - i); // between i and N-1
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        private static void exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private static int uniform(int n)
        {
            Random random = new Random();
            return random.Next(n);
        }
    }
}