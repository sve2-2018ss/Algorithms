namespace DirectedGraphs
{
    public class TransitiveClosure
    {
        private DirectedDFS[] all;

        public TransitiveClosure(DiGraph G)
        {
            all = new DirectedDFS[G.V];
            for (int v = 0; v < G.V; v++)
                all[v] = new DirectedDFS(G, v);
        }

        public bool reachable(int v, int w)
        {
            return all[v].Marked(w);
        }
    }
}