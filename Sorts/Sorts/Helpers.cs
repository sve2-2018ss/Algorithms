using System;
using System.Linq;

namespace Sorts
{
    public static class Helpers
    {
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