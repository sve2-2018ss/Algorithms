using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph gr=new Graph(4);
            gr.addEdge(1, 2);
            gr.addEdge(2, 3);
            gr.addEdge(2, 4);

            Console.WriteLine(gr);
            Console.WriteLine("Max Degree : {0}",gr.maxDegree());
            Console.WriteLine("Avg Degree : {0}", gr.avgDegree());

            DepthFirstSearch search1=new DepthFirstSearch(gr, 4);
            Console.Write("Graph ");
            search1.Show();
            int point = 4;
            Console.WriteLine("{1} path to {0}", point, search1.hasPathTo(point)? "Has" : "Hasn't");

            Paths search = new Paths(gr, point);
            for (int v = 1; v <= gr.V; v++)
            {
                Console.Write(point + " to " + v + ": ");
                if (search.hasPathTo(v))
                    foreach (int x in search.pathTo(v))
                        if (x == point) Console.Write(x);
                        else Console.Write("-" + x);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    static class MyExt
    {
        public static int degree(this Graph G, int v)
        {
            int degree = 0;
            foreach (int g in G.Adj(v))
                degree++;
            return degree;
        }

        public static int maxDegree(this Graph G)
        {
            int max = 0;
            for (int v = 0; v < G.V; v++)
                if (degree(G, v) > max)
                    max = degree(G, v);
            return max;
        }

        public static int avgDegree(this Graph G)
        {
            return 2 * G.E / G.V;
        }

        public static int numberOfSelfLoops(this Graph G)
        {
            int count = 0;
            for (int v = 0; v < G.V; v++)
                foreach (int w in G.Adj(v))
                    if (v == w)
                        count++;
            return count / 2; 
        }

        
    }
    
}
