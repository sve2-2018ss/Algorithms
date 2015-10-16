using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MST
{
    class Program
    {
        static void Main(string[] args)
        {
            EdgeWeightedGraph ewg=new EdgeWeightedGraph(5);

            ewg.Filling(5);
            ewg.ShowEdges();
            Console.WriteLine();

            ewg.LazyPrimAlgr();
            Console.WriteLine();

            ewg.PrimAlgr();

            Console.ReadKey();
        }
    }

    public static class Helper
    {
        public static void Filling(this EdgeWeightedGraph ewg,int count)
        {
            for (int i = 0; i < count-1; i++)
            {
                int k = i + 1;
                double weight = (i+k)*(double)count/100;
                ewg.addEdge(new Edge(i,i+1,weight));
            }

            for (int i = 0; i < count - 2; i++)
            {
                int k = i + 2;
                double weight = (i + k) * (double)count / 100;
                ewg.addEdge(new Edge(i, i + 2, weight));
            }
        }

        public static void ShowEdges(this EdgeWeightedGraph ewg)
        {
            foreach (var v in ewg.edges())
            {
                Console.WriteLine(v);
            }
        }

        public static void LazyPrimAlgr(this EdgeWeightedGraph ewg)
        {
            LazyPrimMST lpm= new LazyPrimMST(ewg);
            foreach (var v in lpm.edges())
            {
                Console.WriteLine(v);
            }
            
        }

        public static void PrimAlgr(this EdgeWeightedGraph ewg)
        {
            PrimMST lpm = new PrimMST(ewg);
            foreach (var v in lpm.edges())
            {
                Console.WriteLine(v);
            }

        }
    }
}
