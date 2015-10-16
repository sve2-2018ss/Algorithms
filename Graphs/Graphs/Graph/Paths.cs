using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    /// <summary>
    /// Breadth-first search to find paths in a graph
    /// </summary>
    public class Paths
    {
        private bool[] marked; // Has dfs() been called for this vertex?
        private List<int>[] edgeTo; // last vertex on known path to this vertex
        public readonly int s; // source
        public Paths(Graph G)
        {
            marked = new bool[G.V];
            edgeTo = new List<int>[G.V];
            intEdgeTo();
            this.s = G.V;
            dfs(G, 1);
        }

        private void intEdgeTo()
        {
            for (int i = 0; i < edgeTo.Length; i++)
            {
                edgeTo[i]=new List<int>();
            }
        }

        private void dfs(Graph G, int v)
        {
            marked[v-1] = true;
            foreach (int w in G.Adj(v-1))
                if (!marked[w-1])
                {
                    edgeTo[w - 1].Add(v);
                    edgeTo[v - 1].Add(w);
                    dfs(G, w);
                }
        }

        public bool hasPathTo(int v)
        {
            return marked[v-1];
        }

        public IEnumerable<int> pathTo(int j,int v)
        {
            if (!hasPathTo(v)) return null;

            Stack<int> path = new Stack<int>();
            foreach (var x in pathFind(j, v))
            {
                if(x!=j)
                    path.Push(x);
            }
            return path;
        }

        private List<int> pathFind(int j,int v)
        {
            List<int> path = new List<int>();
            if (edgeTo[j - 1].Contains(v))
            {
                path.Add(v);
                path.Add(j);
                
            }
            else
                path.AddRange(edgeTo[v - 1].SelectMany(n => pathFind(n, v)));

            return path;
        }

        public bool OneWired(int j, int v)
        {

            return pathFind(j, v).Count(i => i != j) == 1;
        }

        public bool Wired(int j, int v)
        {
            return pathFind(j, v).Count != 0;
        }
    }
}