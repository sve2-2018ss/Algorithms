namespace ShortestPath
{
    public class DirectedEdge
    {
        private readonly int v; // edge source
        private readonly int w; // edge target
        private readonly double weight; // edge weight
        public DirectedEdge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public double Weight
        {
            get { return weight; }
        }

        public int from
        {
            get { return v; }
        }

        public int to
        {
            get { return w; }
        }

        public override string ToString()
        {
            return string.Format("{0}->{1} {2}",v,w,weight);
        }
    }
}