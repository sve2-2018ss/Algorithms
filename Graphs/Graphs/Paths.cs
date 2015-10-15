using System.Collections.Generic;

namespace Graphs
{
    public class Paths
    {
        private bool[] marked; // Has dfs() been called for this vertex?
        private int[] edgeTo; // last vertex on known path to this vertex
        private readonly int s; // source
        public Paths(Graph G, int s)
        {
            marked = new bool[G.V];
            edgeTo = new int[G.V];
            this.s = s;
            dfs(G, s);
        }
        private void dfs(Graph G, int v)
        {
            marked[v-1] = true;
            foreach (int w in G.Adj(v-1))
                if (!marked[w-1])
                {
                    edgeTo[w-1] = v;
                    dfs(G, w);
                }
        }

        public bool hasPathTo(int v)
        {
            return marked[v-1];
        }

        public IEnumerable<int> pathTo(int v)
        {
            if (!hasPathTo(v)) return null;
            Stack<int> path = new Stack<int>();
            for (int x = v; x != s; x = edgeTo[x])
                path.Push(x);
            path.Push(s);
            return path;
        }
    }
}