using System.Collections.Generic;

namespace ShortestPath
{
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre; // vertices in preorder
        private Queue<int> post; // vertices in postorder
        private Stack<int> reversePost; // vertices in reverse postorder
        public DepthFirstOrder(EdgeWeightedDigraph G)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
                if (!marked[v])
                    dfs(G, v);
        }
        private void dfs(EdgeWeightedDigraph G, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (var w in G.Adj(v))
                if (!marked[w.from])
                    dfs(G, w.from);
            post.Enqueue(v);
            reversePost.Push(v);
        }

        public IEnumerable<int> Pre()
        {
            return pre;
        }

        public IEnumerable<int> Post()
        {
            return post;
        }

        public IEnumerable<int> ReversePost()
        {
            return reversePost;
        }
    }
}