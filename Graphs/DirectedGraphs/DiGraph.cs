using System.Collections.Generic;
using System.Text;

namespace DirectedGraphs
{
    public class DiGraph
    {
        private readonly int _V;
        private int _E;
        private List<int>[] adj;

        public DiGraph(int V)
        {
            this._V = V;
            this._E = 0;
            adj = new List<int>[V];
            for (int v = 0; v < V; v++)
                adj[v] = new List<int>();
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
            adj[v].Add(w);
            _E++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public DiGraph reverse()
        {
            DiGraph R = new DiGraph(V);
            for (int v = 0; v < V; v++)
                foreach (int w in Adj(v))
                    R.addEdge(w, v);
            return R;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0} vertices, {1} edges\n", V, E);
            for (int v = 0; v < V; v++)
            {
                s.AppendFormat("{0}: ", v);
                foreach (int w in Adj(v))
                    s.AppendFormat("{0} ", w);
                s.Append("\n");
            }
            return s.ToString();
        }
    }
}