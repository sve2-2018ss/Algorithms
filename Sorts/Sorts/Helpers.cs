using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Sorts
{
    public static class Helpers
    {
        public static void CompareSorts(IComparable[] data)
        {
            var temp = (IComparable[]) data.Clone();
            Stopwatch time=new Stopwatch();
            time.Start();
            Selection.Sort(temp);
            time.Stop();
            var first = time.Elapsed;
            temp= (IComparable[])data.Clone();
            time.Restart();
            Insertion.Sort(temp);
            time.Stop();
            var second = time.Elapsed;
            if (first < second) Console.WriteLine("Selection sort faster");
            if (first > second) Console.WriteLine("Insertion sort faster");
            if (first == second) Console.WriteLine("Sorts equality");
        }

        public static void exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void Show(IComparable[] a,string message="")
        {
            Console.WriteLine("\n---{0}---",message);
            a.All(i =>
            {
                Console.WriteLine(i);
                return true;
            });
            Console.WriteLine("---===---\n");
        }
    }
}