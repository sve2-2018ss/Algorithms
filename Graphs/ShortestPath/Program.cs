using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EdgeWeightedDigraph ewg = new EdgeWeightedDigraph(5);

            ewg.Filling(5);
            ewg.ShowEdges();
            Console.WriteLine();

            /*Console.WriteLine("Dijkstra Paths :");
            ewg.ShowPathsByDijkstra();
            Console.WriteLine();*/

            /*Console.WriteLine("Acyclic Paths");
            ewg.ShowPathsByAcyclic();
            Console.WriteLine();*/

            Console.WriteLine("BellmanFord Paths");
            ewg.ShowPathsByBellmanFord();
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public static class Helper
    {
        public static void Filling(this EdgeWeightedDigraph ewg, int count)
        {
            for (int i = 0; i < count - 1; i++)
            {
                int k = i + 1;
                double weight = (i + k)*(double) count/100;
                ewg.addEdge(new DirectedEdge(i, i + 1, weight));
            }

            for (int i = 0; i < count - 2; i++)
            {
                int k = i + 2;
                double weight = (i + k)*(double) count/100;
                ewg.addEdge(new DirectedEdge(i, i + 2, weight));
            }
        }

        public static void ShowEdges(this EdgeWeightedDigraph ewg)
        {
            foreach (var v in ewg.edges())
            {
                Console.WriteLine(v);
            }
        }

        public static void ShowPathsByDijkstra(this EdgeWeightedDigraph ewg)
        {
            DijkstraAllPairsSP dapsp=new DijkstraAllPairsSP(ewg);
            for (int i = 0; i < ewg.V; i++)
            {
                for (int j = 0; j < ewg.V; j++)
                {
                    if (dapsp.hasPathTo(i, j) && i != j)
                    {
                        Console.WriteLine("{0}-{1} : ", i, j);
                        foreach (var v in dapsp.path(i, j))
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("------------------");
                    }
                }
            }
        }

        public static bool hasCycles(this EdgeWeightedDigraph ewg)
        {
            DirectedCycle dc=new DirectedCycle(ewg);
            return dc.hasCycle();
        }

        public static void ShowPathsByAcyclic(this EdgeWeightedDigraph ewg)
        {
            for (int i = 0; i < ewg.V; i++)
            {
                AcyclicSP dapsp = new AcyclicSP(ewg, i);
                for (int j = 0; j < ewg.V; j++)
                {
                    if (dapsp.hasPathTo(j) && i!=j)
                    {
                        Console.WriteLine("{0}-{1} : ", i, j);
                        foreach (var v in dapsp.pathTo(j))
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("------------------");
                    }
                }
            }
        }

        public static void ShowPathsByBellmanFord(this EdgeWeightedDigraph ewg)
        {
            for (int i = 0; i < ewg.V; i++)
            {
                BellmanFordSP dapsp = new BellmanFordSP(ewg, i);
                for (int j = 0; j < ewg.V; j++)
                {
                    if (dapsp.hasPathTo(j) && i != j)
                    {
                        Console.WriteLine("{0}-{1} : ", i, j);
                        foreach (var v in dapsp.pathTo(j))
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("------------------");
                    }
                }
            }
        }
    }
}