using System.Collections.Generic;
using System.Linq;

namespace MST
{
    public class LazyPrimMST
    {
        private bool[] marked; // MST vertices
        private Queue<Edge> mst; // MST edges
        private PriorityQueue<Edge> pq; // crossing (and ineligible) edges
        public LazyPrimMST(EdgeWeightedGraph G)
        {
            
            pq = new PriorityQueue<Edge>(G.V);
            marked = new bool[G.V];
            mst = new Queue<Edge>();
            visit(G, 0); // assumes G is connected (see Exercise 4.3.22)
            while (!pq.isEmpty())
            {
                Edge e = pq.Del(); // Get lowest-weight
                int v = e.either;
                int w = e.other(v); // edge from pq.
                if (marked[v] && marked[w])
                    continue; // Skip if ineligible.
                mst.Enqueue(e); // Add edge to tree.
                if (!marked[v])
                    visit(G, v); // Add vertex to tree
                if (!marked[w])
                    visit(G, w); // (either v or w).
            }
        }
        private void visit(EdgeWeightedGraph G, int v)
        { // Mark v and add to pq all edges from v to unmarked vertices.
            marked[v] = true;
            foreach (Edge e in G.Adj(v))
                if (!marked[e.other(v)])
                    pq.Insert(e);
        }

        public IEnumerable<Edge> edges()
        {
            return mst;
        }
        public double weight()
        {
            return edges().Sum(v => v.Weight);
        }
    }
}