using System.Collections.Generic;
using System.Text;

namespace Context
{
    public class FlowNetwork
    {
        private readonly int _V; // number of vertices
        private int _E; // number of edges
        private List<FlowEdge>[] adj; // adjacency lists

        public FlowNetwork(int V)
        {
            this._V = V;
            this._E = 0;
            adj = new List<FlowEdge>[_V]; // Create array of lists.
            for (int v = 0; v < _V; v++) // Initialize all lists
                adj[v] = new List<FlowEdge>(); // to empty.
        }

        public int V
        {
            get
            {
                return _V;
            }
        }
        public int E
        {
            get
            {
                return _E;
            }
        }

        public void addEdge(FlowEdge v)
        {
            adj[_E++].Add(v);
        }

        public IEnumerable<FlowEdge> Adj(int v)
        {
            return adj[v];
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0} vertices, {1} edges\n", V, E);
            for (int v = 0; v < V; v++)
            {
                s.AppendFormat("{0}: ", v + 1);
                foreach (var w in Adj(v))
                    s.AppendFormat("{0} ", w);
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}