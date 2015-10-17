using System;
using System.Collections.Generic;

namespace ShortestPath
{
    public class BellmanFordSP
    {
        private double[] distTo; // length of path to v
        private DirectedEdge[] edgeTo; // last edge on path to v
        private bool[] onQ; // Is this vertex on the queue?
        private Queue<int> queue; // vertices being relaxed
        private int cost; // number of calls to relax()
        private IEnumerable<DirectedEdge> cycle; // negative cycle in edgeTo[]?

        public BellmanFordSP(EdgeWeightedDigraph G, int s)
        {
            distTo = new double[G.V];
            edgeTo = new DirectedEdge[G.V];
            onQ = new bool[G.V];
            queue = new Queue<int>();
            for (int v = 0; v < G.V; v++)
                distTo[v] = double.PositiveInfinity;
            distTo[s] = 0.0;
            queue.Enqueue(s);
            onQ[s] = true;
            while (queue.Count!=0 && !this.hasNegativeCycle())
            {
                int v = queue.Dequeue();
                onQ[v] = false;
                relax(G,v);
            }
        }

        private void relax(EdgeWeightedDigraph G, int v)
        {
            foreach (DirectedEdge e in G.Adj(v))
            {
                int w = e.to;
                if (distTo[w] > distTo[v] + e.Weight)
                {
                    distTo[w] = distTo[v] + e.Weight;
                    edgeTo[w] = e;
                    if (!onQ[w])
                    {
                        queue.Enqueue(w);
                        onQ[w] = true;
                    }
                }
                if (cost++%G.V == 0)
                    findNegativeCycle();
            }
        }

        public double DistTo(int v)
        {
            return distTo[v];
        }

        public bool hasPathTo(int v)
        {
            return distTo[v] < double.PositiveInfinity;
        } 

        public IEnumerable<DirectedEdge> pathTo(int v)
        {
            if (!hasPathTo(v)) return null;
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.from])
                path.Push(e);
            return path;
        }

        private void findNegativeCycle()
        {
            int V = edgeTo.Length;
            EdgeWeightedDigraph spt;
            spt = new EdgeWeightedDigraph(V);
            for (int v = 0; v < V; v++)
                if (edgeTo[v] != null)
                    spt.addEdge(edgeTo[v]);
            DirectedCycle cf = new DirectedCycle(spt);
            cycle = cf.Cycle();
        }

        public bool hasNegativeCycle()
        {
            return cycle != null;
        }

        public IEnumerable<DirectedEdge> negativeCycle()
        {
            return cycle;
        }
    }
}