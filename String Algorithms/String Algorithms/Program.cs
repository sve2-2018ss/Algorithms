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
            #region strings sorts

            /*string[] strs = new string[]
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

            strs.Show();*/

            #endregion

            #region Tries
            TrieST<int> tst = new TrieST<int>();
            tst.put("by", 4);
            tst.put("sea", 2);
            tst.put("sells", 1);
            tst.put("she", 0);
            tst.put("shells", 3);
            tst.put("the", 5);

            foreach (var key in tst.keys())
            {
                Console.WriteLine(key);
            }
            #endregion
            
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
