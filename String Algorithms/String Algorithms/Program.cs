using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs=new string[]
            {
                "4PGC938",
                "2IYE230",
                "3CIO720",
                "1ICK750",
                "1OHV845",
                "4JZY524",
                "1ICK750",
                "3CIO720",
                "1OHV845",
                "1OHV845",
                "2RLA629",
                "2RLA629",
                "3ATW723"
            };

            strs.Show();
            Console.WriteLine();

            //LSD.sort(strs,7);
            //MSD.sort(strs);
            Quick3string.sort(strs);

            strs.Show();
            Console.ReadKey();

        }
    }

    public static class Helpers
    {
        public static void Show(this string[] strs)
        {
            foreach (var str in strs)
            {
                Console.WriteLine(str);
            }
        }
    }
}
