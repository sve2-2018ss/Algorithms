using System.Collections.Generic;
using System.Linq;

namespace MST
{
    public class EdgeWeightedGraph
    {
        private readonly int _V; // number of vertices
        private int _E; // number of edges
        private List<Edge>[] adj; // adjacency lists

        public EdgeWeightedGraph(int V)
        {
            this._V = V;
            this._E = 0;
            adj = new List<Edge>[V];
            for (int v = 0; v < V; v++)
                adj[v] = new List<Edge>();
        }
        
        public int V
        {
            get { return _V; }
        }

        public int E
        {
            get { return _E; }
        }

        public void addEdge(Edge e)
        {
            int v = e.either;
            int w = e.other(v);
            adj[v].Add(e);
            adj[w].Add(e);
            _E++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return adj[v];
        }

        public IEnumerable<Edge> edges()
        {
            List<Edge> b = new List<Edge>();
            for (int v = 0; v < V; v++)
                b.AddRange(adj[v].Where(e => e.other(v) > v));
            return b;
        }
    }
}