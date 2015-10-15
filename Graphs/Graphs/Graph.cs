using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class Graph
    {
        private readonly int _V; // number of vertices
        private int _E; // number of edges
        private List<int>[] adj; // adjacency lists

        public Graph(int V)
        {
            this._V = V;
            this._E = 0;
            adj = new List<int>[_V]; // Create array of lists.
            for (int v = 0; v < _V; v++) // Initialize all lists
                adj[v] = new List<int>(); // to empty.
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
        public void addEdge(int v, int w)
        {
            adj[v-1].Add(w); // Add w to v’s list.
            adj[w-1].Add(v); // Add v to w’s list.
            _E++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public override string ToString()
        {
            StringBuilder s =new StringBuilder();
            s.AppendFormat("{0} vertices, {1} edges\n",V,E);
            for (int v = 0; v < V; v++)
            {
                s.AppendFormat("{0}: ",v+1);
                foreach (int w in Adj(v))
                    s.AppendFormat("{0} ",w);
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}