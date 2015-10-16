using System.Collections.Generic;

namespace DirectedGraphs
{
    public class DirectedDFS
    {
        private bool[] marked;
        public DirectedDFS(DiGraph G, int s)
        {
            if (s < 0 || s > G.V-1)
                s = G.V-1;
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