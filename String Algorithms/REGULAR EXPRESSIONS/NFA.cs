using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REGULAR_EXPRESSIONS
{
    public class NFA
    {
        private char[] re; // match transitions
        private DiGraph G; // epsilon transitions
        private int M; // number of states

        public NFA(string regexp)
        { // Create the NFA for the given regular expression.
            Stack<int> ops = new Stack<int>();
            re = regexp.ToCharArray();
            M = re.Length;
            G = new DiGraph(M + 1);
            for (int i = 0; i < M; i++)
            {
                int lp = i;
                if (re[i] == '(' || re[i] == '|')
                    ops.Push(i);
                else if (re[i] == ')')
                {
                    int or = ops.Pop();
                    if (re[or] == '|')
                    {
                        lp = ops.Pop();
                        G.addEdge(lp, or + 1);
                        G.addEdge(or, i);
                    }
                    else lp = or;
                }
                if (i < M - 1 && re[i + 1] == '*') // lookahead
                {
                    G.addEdge(lp, i + 1);
                    G.addEdge(i + 1, lp);
                }
                if (re[i] == '(' || re[i] == '*' || re[i] == ')')
                    G.addEdge(i, i + 1);
            }
        }
        public bool recognizes(string txt)
        { // Does the NFA recognize txt?
            List<int> pc = new List<int>();
            DirectedDFS dfs = new DirectedDFS(G, 0);
            for (int v = 0; v < G.V; v++)
                if (dfs.Marked(v))
                    pc.Add(v);
            foreach (char t in txt)
            {// Compute possible NFA states for txt[i+1].
                List<int> match = (from v in pc where v < M where re[v] == t || re[v] == '.' select v + 1).ToList();
                pc = new List<int>();
                dfs = new DirectedDFS(G, match);
                for (int v = 0; v < G.V; v++)
                    if (dfs.Marked(v))
                        pc.Add(v);
            }
            return pc.Any(v => v == M);
        }
    }

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

    public class DirectedDFS
    {
        private bool[] marked;
        public DirectedDFS(DiGraph G, int s)
        {
            if (s < 0 || s > G.V - 1)
                s = G.V - 1;
            marked = new bool[G.V];
            dfs(G, s);
        }
        public DirectedDFS(DiGraph G, IEnumerable<int> sources)
        {
            marked = new bool[G.V];
            foreach (int s in sources)
                if (!marked[s])
                    dfs(G, s);
        }
        private void dfs(DiGraph G, int v)
        {
            marked[v] = true;
            foreach (int w in G.Adj(v))
                if (!marked[w])
                    dfs(G, w);
        }

        public bool Marked(int v)
        {
            return marked[v];
        }
    }
}