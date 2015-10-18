using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGULAR_EXPRESSIONS
{
    class Program
    {
        static void Main(string[] args)
        {
            NFA nfa= new NFA("(A*B|AC)D");

            Console.Write("Write string to recognize: ");
            Console.WriteLine("Recognized : {0}",nfa.recognizes(Console.ReadLine()));

            Console.ReadKey();
        }

        
    }
}
