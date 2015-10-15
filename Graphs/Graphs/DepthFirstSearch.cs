using System;
using System.Collections.Generic;

namespace Graphs
{
    public class DepthFirstSearch
    {
        private bool[] marked;
        private int count;
        private int size;

        public DepthFirstSearch(Graph G, int s)
        {
            if (s < 1 || s > G.V)
                s = G.V;
            marked = new bool[G.V];
            dfs(G, s);
            size = G.V;
        }
        private void dfs(Graph G, int v)
        {
            marked[v-1] = true;
            count++;
            foreach (int w in G.Adj(v-1))
                if (!marked[w-1]) dfs(G, w);
        }

        public bool Marked(int w)
        {
            return marked[w];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool hasPathTo(int v)
        {
            return marked[v-1];
        }

        public void Show()
        {
            if (Count != size)
                Console.Write("NOT ");
            Console.WriteLine("connected");
        }
        
    }
}