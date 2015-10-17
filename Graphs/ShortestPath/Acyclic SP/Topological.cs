using System.Collections.Generic;

namespace ShortestPath
{
    public class Topological
    {
        private IEnumerable<int> order; // topological order

        public Topological(EdgeWeightedDigraph G)
        {
            DirectedCycle cyclefinder = new DirectedCycle(G);
            if (!cyclefinder.hasCycle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(G);
                order = dfs.ReversePost();
            }
        }

        public IEnumerable<int> Order
        {
            get
            {
                return order;
            }
        }

        public bool isDAG()
        {
            return order == null;
        }
    }
}