namespace DirectedGraphs
{
    public class KosarajuSCC
    {
        private bool[] marked; // reached vertices
        private int[] id; // component identifiers
        private int count; // number of strong components
        public KosarajuSCC(DiGraph G)
        {
            marked = new bool[G.V];
            id = new int[G.V];
            DepthFirstOrder order = new DepthFirstOrder(G.reverse());
            foreach (int s in order.ReversePost())
                if (!marked[s])
                { dfs(G, s); count++; }
        }
        private void dfs(DiGraph G, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (int w in G.Adj(v))
                if (!marked[w])
                    dfs(G, w);
        }

        public bool stronglyConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}