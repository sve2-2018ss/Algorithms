using System.Collections.Generic;

namespace DirectedGraphs
{
    public class Topological
    {
        private IEnumerable<int> order; // topological order

        public Topological(DiGraph G)
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