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

            ewg.ShowPaths();

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

        public static void ShowPaths(this EdgeWeightedDigraph ewg)
        {
            DijkstraAllPairsSP dapsp=new DijkstraAllPairsSP(ewg);
            for (int i = 0; i < ewg.V; i++)
            {
                for (int j = 0; j < ewg.V; j++)
                {
                    if (i != j)
                    {
                        if (dapsp.hasPathTo(i, j))
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
        }
    }
}