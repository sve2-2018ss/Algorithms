using System;
using System.Collections.Generic;

namespace ShortestPath
{
    public class DijkstraSP
    {
        private DirectedEdge[] edgeTo;
        private double[] distTo;
        private IndexPriorityQueue<double> pq;
        public DijkstraSP(EdgeWeightedDigraph G, int s)
        {
            edgeTo = new DirectedEdge[G.V];
            distTo = new double[G.V];
            pq = new IndexPriorityQueue<double>(G.V);
            for (int v = 0; v < G.V; v++)
                distTo[v] = Double.PositiveInfinity;
            distTo[s] = 0.0;
            pq.Insert(s, 0.0);
            while (!pq.isEmpty())
                relax(G, pq.Del());
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
                    if (pq.contains(w)) pq.change(w, distTo[w]);
                    else pq.Insert(w, distTo[w]);
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

    public class DijkstraAllPairsSP
    {
        private DijkstraSP[] all;

        public DijkstraAllPairsSP(EdgeWeightedDigraph G)
        {
            all = new DijkstraSP[G.V];
            for (int v = 0; v < G.V; v++)
                all[v] = new DijkstraSP(G, v);
        }

        public IEnumerable<DirectedEdge> path(int s, int t)
        {
            return all[s].pathTo(t);
        }

        public bool hasPathTo(int i,int j)
        {
            return all[i].pathTo(j)!=null;
        }

        public double dist(int s, int t)
        {
            return all[s].DistTo(t);
        }
    }
}