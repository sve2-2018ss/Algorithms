using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.ST
{
    class Program
    {
        static void Main(string[] args)
        {
            SymbolTable<int,string> St=new SymbolTable<int, string>();
            for (int i=0;i<5;i++)
                Put(St);

            Console.WriteLine("Min Key : {0}",St.min());
            Console.WriteLine("Max Key : {0}", St.max());
            St.Show();
            St.SortedShow();

            Console.ReadKey();
        }

        static void Put(SymbolTable<int,string> st)
        {
            Console.Write("Insert Key :");
            int key = int.Parse(Console.ReadLine());
            Console.Write("Insert Value :");
            st.put(key,Console.ReadLine());
        }
    }
}
