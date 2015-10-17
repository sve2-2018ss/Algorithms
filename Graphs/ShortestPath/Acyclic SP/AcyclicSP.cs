using System;
using System.Collections.Generic;

namespace ShortestPath
{
    public class AcyclicSP
    {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        public AcyclicSP(EdgeWeightedDigraph G, int s)
        {
            edgeTo = new DirectedEdge[G.V];
            distTo = new double[G.V];
            for (int v = 0; v < G.V; v++)
                distTo[v] = double.PositiveInfinity;
            distTo[s] = 0.0;
            Topological top = new Topological(G);
            foreach (int v in top.Order)
                relax(G, v);
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
                }
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
    }
}