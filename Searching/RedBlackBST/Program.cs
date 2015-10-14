using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBlackBST
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<int, string> bst = new BST<int, string>();
            bst.put(5, "Alex");
            bst.put(4, "Anna");
            bst.put(3, "Aliona");
            bst.put(2, "Sergey");
            bst.put(1, "Olga");

            bst.print();

            Console.ReadKey();
        }
    }
}
