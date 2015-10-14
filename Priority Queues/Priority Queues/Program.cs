using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print the top M lines in the input stream.
            Console.Write("Write Lenth : ");
            int M = int.Parse(Console.ReadLine());
            Console.Write("Write Del max(True) or min(False) : ");
            bool b = false;
            bool.TryParse(Console.ReadLine(),out b);

            PriorityQueue<int> pq = new PriorityQueue<int>(M,b);

            Console.WriteLine("Insert Queue : ");
            for(int i=0;i<M;i++)
                pq.Insert(int.Parse(Console.ReadLine()));

            Stack<int> stack = new Stack<int>();

            while (!pq.isEmpty())
                stack.push(pq.Del());

            Console.WriteLine("\n\t OutPut Stack");
            while(!stack.isEmpty())
                Console.WriteLine(stack.pull());

            Console.ReadKey();
        }
    }
}
