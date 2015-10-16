using System.Collections.Generic;

namespace DirectedGraphs
{
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> pre; // vertices in preorder
        private Queue<int> post; // vertices in postorder
        private Stack<int> reversePost; // vertices in reverse postorder
        public DepthFirstOrder(DiGraph G)
        {
            pre = new Queue<int>();
            post = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[G.V];
            for (int v = 0; v < G.V; v++)
                if (!marked[v])
                    dfs(G, v);
        }
        private void dfs(DiGraph G, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (int w in G.Adj(v))
                if (!marked[w])
                    dfs(G, w);
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