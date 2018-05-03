using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Sorts
{
    public static class Helpers
    {
        public static void CompareElementarySorts(IComparable[] data)
        {
            var temp = (IComparable[])data.Clone();
            Stopwatch time = new Stopwatch();
            time.Start();
            Selection.Sort(temp);
            time.Stop();
            List<TimeSpan> times = new List<TimeSpan>();
            times.Add(time.Elapsed);
            temp = (IComparable[])data.Clone();
            time.Restart();
            Insertion.Sort(temp);
            time.Stop();
            times.Add(time.Elapsed);
            temp = (IComparable[])data.Clone();
            time.Restart();
            Shell.Sort(temp);
            time.Stop();
            times.Add(time.Elapsed);
            var min = Helpers.Min(times);
            if (times[0] == min && times[1] == min && times[2] == min)
            {
                Console.WriteLine("Sorts equality");
                return;
            }
            if (times[0] == min)
                Console.WriteLine("Selection sort faster");
            if (times[1] == min)
                Console.WriteLine("Insertion sort faster");
            if (times[2] == min)
                Console.WriteLine("Shell sort faster");
        }

        public static void CompareMergeSorts(IComparable[] data)
        {
            var temp = (IComparable[])data.Clone();
            Stopwatch time = new Stopwatch();
            time.Start();
            new Merge().TopDownSort(temp);
            time.Stop();
            List<TimeSpan> times = new List<TimeSpan>();
            times.Add(time.Elapsed);
            temp = (IComparable[])data.Clone();
            time.Restart();
            new Merge().BottomUpSort(temp);
            time.Stop();
            times.Add(time.Elapsed);
            var min = Helpers.Min(times);
            if (times.All(i => i == min))
            {
                Console.WriteLine("Sorts equality");
                return;
            }
            if (times[0] == min)
                Console.WriteLine("opp down sort faster");
            if (times[1] == min)
                Console.WriteLine("Bottom up sort faster");
        }

        public static void CompareQuickSorts(IComparable[] data)
        {
            var temp = (IComparable[])data.Clone();
            Stopwatch time = new Stopwatch();
            time.Start();
            new Quick().Sort(temp);
            time.Stop();
            List<TimeSpan> times = new List<TimeSpan>();
            times.Add(time.Elapsed);
            temp = (IComparable[])data.Clone();
            time.Restart();
            new Quick3Way().Sort(temp);
            time.Stop();
            times.Add(time.Elapsed);
            var min = Helpers.Min(times);
            if (times.All(i => i == min))
            {
                Console.WriteLine("Sorts equality");
                return;
            }
            if (times[0] == min)
                Console.WriteLine("Quick sort faster");
            if (times[1] == min)
                Console.WriteLine("Quick3Way sort faster");
        }

        public static T Min<T>(List<T> list) where T : IComparable
        {
            var min = list.First();
            foreach (var v in list)
            {
                if (v.CompareTo(min) == -1)
                    min = v;
            }
            return min;
        }

        public static void exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static void Show(IComparable[] a, string message = "")
        {
            Console.WriteLine("\n---{0}---", message);
            a.All(i =>
            {
                Console.WriteLine(i);
                return true;
            });
            Console.WriteLine("---===---\n");
        }

        public static void shuffle(IComparable[] a)
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

        private static int uniform(int n)
        {
            Random random = new Random();
            return random.Next(n);
        }
    }
}