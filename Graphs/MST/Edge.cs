using System;

namespace MST
{
    public class Edge :IComparable<Edge>
    {
        private readonly int v; // one vertex
        private readonly int w; // the other vertex
        private readonly double weight; // edge weight

        public Edge(int v, int w, double weight)
{
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight
        {
            get
            {
                return weight;
            }
        }

        public int either
        {
            get
            {
                return v;
            }
        }

        public int other(int vertex)
        {
            if (vertex == v) return w;
            else if (vertex == w) return v;
            else throw new Exception("Inconsistent edge");
        }
        public int CompareTo(Edge that)
{
            if (this.weight < that.weight) return -1;
            else if (this.weight > that.weight) return 1;
            else return 0;
        }

        public override string ToString()
        {
            return $"Edge {v}-{w}, Weight: {weight}";
        }
    }
}