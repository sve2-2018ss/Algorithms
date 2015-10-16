using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class SymbolGraph
    {
        private Dictionary<string, int> st; // String -> index
        private string[] keys; // index -> String
        private Graph G; // the graph
        private int count;
        private int N=0;

        public SymbolGraph(int count=5)
        {
            this.count = count;
            keys=new string[count];
            st = new Dictionary<string, int>();
            G=new Graph(count);
        }

        public void AddPoint(string key)
        {
            st.Add(key,++N);
            keys[N-1] = key;
        }

        public void AddWire(string key1,string key2)
        {
            G.addEdge(st[key1],st[key2]);
        }

        public void AddWire(int key1, int key2)
        {
            G.addEdge(key1, key2);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0} vertices, {1} edges\n", G.V, G.E);
            for (int v = 0; v < G.V; v++)
            {
                s.AppendFormat("{0}: ", name(v));
                foreach (int w in G.Adj(v))
                    s.AppendFormat("{0} ", name(w-1));
                s.Append("\n");
            }
            return s.ToString();
        }

        public bool contains(string s)
        {
            return st.ContainsKey(s);
        }

        public int index(string s)
        {
            return st[s];
        }

        public string name(int v)
        {
            return keys[v];
        }

        public Graph graph
        {
            get
            {
                return G;
            }
        }
    }
}