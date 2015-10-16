using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            DiGraph dg=new DiGraph(5);

            dg.addEdge(0, 1);
            dg.addEdge(1, 2);
            dg.addEdge(1, 3);
            dg.addEdge(2, 4);
            //dg.addEdge(4, 0); //Comment it for topological
            dg.addEdge(4, 3);

            Console.WriteLine(dg);
            
            dg.ShowMarked();
            
            dg.ShowCycle();

            dg.ShowTopological();

            Console.WriteLine("{0}-{1} is strongly connected : {2}", 0, 1, dg.isStonglyConnected(0, 1));

            Console.WriteLine("{0}-{1} is reachable : {2}", 0, 3, dg.Reachable(0, 3));

            Console.ReadKey();
        }
    }

    public static class Helper
    {
        public static void ShowMarked(this DiGraph dg)
        {
            Console.Write("Marked: ");
            DirectedDFS reachable = new DirectedDFS(dg, dg.V);
            for (int v = 0; v < dg.V; v++)
                if (reachable.Marked(v))
                    Console.Write(v + " ");
            Console.WriteLine();
        }

        public static void ShowCycle(this DiGraph dg)
        {
            DirectedCycle Cycle = new DirectedCycle(dg);
            if (Cycle.hasCycle())
            {
                Console.Write("Directed Graph Cycled in : ");
                foreach (var e in Cycle.Cycle())
                {
                    Console.Write("{0} ", e);
                }
                Console.WriteLine();
            }
        }

        public static void ShowTopological(this DiGraph dg)
        {
            Topological top = new Topological(dg);
            if (top.isDAG()) return;
            Console.Write("Topological: ");
            foreach (int v in top.Order)
                Console.Write("{0} ",v);
            Console.WriteLine();
        }

        public static bool isStonglyConnected(this DiGraph dg,int first,int second)
        {
            KosarajuSCC scc=new KosarajuSCC(dg);
            return scc.stronglyConnected(first, second);
        }

        public static bool Reachable(this DiGraph dg, int first, int second)
        {
            TransitiveClosure ts=new TransitiveClosure(dg);
            return ts.reachable(first, second);
        }
    }
}
