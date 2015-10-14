using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<int,string> bst=new BST<int, string>();
            bst.put(5,"Alex");
            bst.put(4,"Anna");
            bst.put(6, "Aliona");
            bst.put(3,"Sergey");
            bst.put(7,"Olga");

            bst.print();

            Console.WriteLine("Max : {0}", bst.max());
            Console.WriteLine("Min : {0}", bst.min());

            Console.ReadKey();
        }
    }
}
