using System.Collections.Generic;

namespace ShortestPath
{
    public class DirectedCycle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<DirectedEdge> cycle; // vertices on a cycle (if one exists)
        private bool[] onStack; // vertices on recursive call stack
        public DirectedCycle(EdgeWeightedDigraph G)
        {
            onStack = new bool[G.V];
            edgeTo = new int[G.V];
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
                if (!marked[v])
                    dfs(G, v);
        }
        private void dfs(EdgeWeightedDigraph G, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (var w in G.Adj(v))
                if (this.hasCycle())
                    return;
                else if (!marked[w.to])
                {
                    edgeTo[w.to] = v;
                    dfs(G, w.to);
                }
                else if (onStack[w.to])
                {
                    cycle = new Stack<DirectedEdge>();
                    for (int x = v; x != w.to; x = edgeTo[x])
                        //cycle.Push(x);
                    cycle.Push(w);
                    //cycle.Push(v);
                }
            onStack[v] = false;
        }

        public bool hasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<DirectedEdge> Cycle()
        { return cycle; }
    }
}