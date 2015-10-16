using System;
using System.Collections.Generic;
using System.Linq;

namespace MST
{
    public class PrimMST
    {
        private Edge[] edgeTo; // shortest edge from tree vertex
        private double[] distTo; // distTo[w] = edgeTo[w].weight()
        private bool[] marked; // true if v on tree
        private IndexPriorityQueue<Double> pq; // eligible crossing edges
        public PrimMST(EdgeWeightedGraph G)
        {
            edgeTo = new Edge[G.V];
            distTo = new double[G.V];
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
                distTo[v] = Double.PositiveInfinity;
            pq = new IndexPriorityQueue<double>(G.V);
            distTo[0] = 0.0;
            pq.Insert(0, 0.0); // Initialize pq with 0, weight 0.
            while (!pq.isEmpty())
                visit(G, pq.Del()); // Add closest vertex to tree.
        }
        private void visit(EdgeWeightedGraph G, int v)
        { // Add v to tree; update data structures.
            marked[v] = true;
            foreach (Edge e in G.Adj(v))
            {
                int w = e.other(v);
                if (marked[w]) continue; // v-w is ineligible.
                if (e.Weight < distTo[w])
                { // Edge e is new best connection from tree to w.
                    edgeTo[w] = e;
                    distTo[w] = e.Weight;
                    if (pq.contains(w)) pq.change(w, distTo[w]);
                    else pq.Insert(w, distTo[w]);
                }
            }
        }

        public IEnumerable<Edge> edges()
        {
            List<Edge> mst = new List<Edge>();
            for (int v = 1; v < edgeTo.Length; v++)
                mst.Add(edgeTo[v]);
            return mst;
        }

        public double weight()
        {
            return edges().Sum(v => v.Weight);
        }
    }
}