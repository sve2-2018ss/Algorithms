using System.Collections.Generic;

namespace DirectedGraphs
{
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> cycle; // vertices on a cycle (if one exists)
        private bool[] onStack; // vertices on recursive call stack
        public DirectedCycle(DiGraph G)
        {
            onStack = new bool[G.V];
            edgeTo = new int[G.V];
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
                if (!marked[v])
                    dfs(G, v);
        }
        private void dfs(DiGraph G, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (int w in G.Adj(v))
                if (this.hasCycle())
                    return;
                else if (!marked[w])
                {
                    edgeTo[w] = v;
                    dfs(G, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    for (int x = v; x != w; x = edgeTo[x])
                        cycle.Push(x);
                    cycle.Push(w);
                    cycle.Push(v);
                }
            onStack[v] = false;
        }

        public bool hasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> Cycle()
        { return cycle; }
    }
}