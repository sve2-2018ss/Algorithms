namespace Graphs
{
    public class Cycle
    {
        private bool[] marked;
        private bool hasCycle;
        public Cycle(Graph G)
        {
            marked = new bool[G.V];
            for (int s = 1; s <= G.V; s++)
                if (!marked[s-1])
                    dfs(G, s, s);
        }
        private void dfs(Graph G, int v, int u)
        {
            marked[v-1] = true;
            foreach (int w in G.Adj(v-1))
                if (!marked[w-1])
                    dfs(G, w, v);
                else if (w != u) hasCycle = true;
        }

        public bool HasCycle
        {
            get
            {
                return hasCycle;
            }
        }
    }
}