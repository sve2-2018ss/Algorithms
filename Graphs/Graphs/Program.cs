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

            gr.addEdge(2, 1); // add to Cycled

            Console.WriteLine(gr);

            #region Depthfirstsearch

            /*Console.WriteLine("Max Degree : {0}",gr.maxDegree());
            Console.WriteLine("Avg Degree : {0}", gr.avgDegree());

            DepthFirstSearch search1=new DepthFirstSearch(gr, 4);
            Console.Write("Graph ");
            search1.Show();
            int point = 2;
            Console.WriteLine("{1} path to {0}", point, search1.hasPathTo(point)? "Has" : "Hasn't");*/

            #endregion

            #region Paths

            //Paths search = new Paths(gr);
            //search.ShowPaths();
            //search.ShowHowWired();

            #endregion

            #region Cycle

            Cycle cycle = new Cycle(gr);
            Console.WriteLine("Graph {0}", cycle.HasCycle ? "Cycled" : "NOT Cycled");

            #endregion




            Console.ReadKey();
        }
    }

    static class MyExt
    {
        public static void ShowPaths(this Paths search)
        {
            for (int v = 1; v <= search.s; v++)
            {
                for (int j = 1; j <= search.s; j++)
                {
                    if (j == v)
                        break;
                    Console.Write("Path {0}-{1} :", j, v);
                    if (search.hasPathTo(v))
                        foreach (int x in search.pathTo(j, v))
                            Console.Write("-" + x);
                    Console.WriteLine();
                }
            }
        }

        public static void ShowHowWired(this Paths search)
        {
            for (int v = 1; v <= search.s; v++)
            {
                for (int j = 1; j <= search.s; j++)
                {
                    if (j == v)
                        break;
                    Console.Write("Path {0}-{1} :", j, v);
                    if (search.hasPathTo(v))
                        if (search.Wired(j, v))
                        {
                            if (search.OneWired(j, v))
                                Console.Write("Straight ");
                            Console.WriteLine("Wired");
                        }
                }
            }
        }

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
