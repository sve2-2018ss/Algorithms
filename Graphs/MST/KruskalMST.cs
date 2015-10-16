using System.Collections.Generic;
using System.Linq;

namespace MST
{
    /*public class KruskalMST
    {
        private Queue<Edge> mst;
        public KruskalMST(EdgeWeightedGraph G)
        {
            mst = new Queue<Edge>();
            PriorityQueue<Edge> pq = new PriorityQueue<Edge>(G.E);
            UF uf = new UF(G.V);
            while (!pq.isEmpty() && mst.Count < G.V - 1)
            {
                Edge e = pq.Del(); // Get min weight edge on pq
                int v = e.either;
                int w = e.other(v); // and its vertices.
                if (uf.connected(v, w))
                    continue; // Ignore ineligible edges.
                uf.union(v, w); // Merge components.
                mst.Enqueue(e); // Add edge to mst.
            }
        }

        public IEnumerable<Edge> edges()
        {
            return mst;
        }

        public double weight()
        {
            return edges().Sum(v => v.Weight);
        }
    }*/
}