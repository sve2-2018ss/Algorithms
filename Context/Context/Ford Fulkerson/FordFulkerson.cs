using System;
using System.Collections.Generic;

namespace Context
{
    public class FordFulkerson
    {
        private bool[] marked; // Is s->v path in residual graph?
        private FlowEdge[] edgeTo; // last edge on shortest s->v path
        private double value; // current value of maxflow

        public FordFulkerson(FlowNetwork G, int s, int t)
        { // Find maxflow in flow network G from s to t.
            while (hasAugmentingPath(G, s, t))
            { // While there exists an augmenting path, use it.
              // Compute bottleneck capacity.
                double bottle = double.PositiveInfinity;
                for (int v = t; v != s; v = edgeTo[v].other(v))
                    bottle = Math.Min(bottle, edgeTo[v].residualCapacityTo(v));
                // Augment flow.
                for (int v = t; v != s; v = edgeTo[v].other(v))
                    edgeTo[v].addResidualFlowTo(v, bottle);
                value += bottle;
            }
        }

        public double Value()
        {
            return value;
        }

        public bool inCut(int v)
        {
            return marked[v];
        }

        private bool hasAugmentingPath(FlowNetwork G, int s, int t)
        {
            marked = new bool[G.V]; // Is path to this vertex known?
            edgeTo = new FlowEdge[G.V]; // last edge on path
            Queue<int> q = new Queue<int>();
            marked[s] = true; // Mark the source
            q.Enqueue(s); // and put it on the queue.
            while (q.Count!=0)
            {
                int v = q.Dequeue();
                foreach (FlowEdge e in G.Adj(v))
                {
                    int w = e.other(v);
                    if (e.residualCapacityTo(w) > 0 && !marked[w])
                    { // For every edge to an unmarked vertex (in residual)
                        edgeTo[w] = e; // Save the last edge on a path.
                        marked[w] = true; // Mark w because a path is known
                        q.Enqueue(w); // and add it to the queue.
                    }
                }
            }
            return marked[t];
        }
    }
}