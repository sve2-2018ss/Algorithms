using System.Collections.Generic;

namespace ShortestPath
{
    public class EdgeWeightedDigraph
    {
        private readonly int _V; // number of vertices
        private int _E; // number of edges
        private List<DirectedEdge>[] adj; // adjacency lists
        public EdgeWeightedDigraph(int V)
        {
            this._V = V;
            this._E = 0;
            adj = new List<DirectedEdge>[V];
            for (int v = 0; v < V; v++)
                adj[v] = new List<DirectedEdge>();
        }

        public int V
        {
            get { return _V; }
        }

        public int E
        {
            get { return _E; }
        }

        public void addEdge(DirectedEdge e)
        {
            adj[e.from].Add(e);
            _E++;
        }

        public IEnumerable<DirectedEdge> Adj(int v)
        {
            return adj[v];
        }

        public IEnumerable<DirectedEdge> edges()
        {
            List<DirectedEdge> bag = new List<DirectedEdge>();
            for (int v = 0; v < V; v++)
                foreach (DirectedEdge e in adj[v])
                    bag.Add(e);
            return bag;
        }
    }
}