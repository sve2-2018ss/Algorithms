using System;

namespace Context
{
    public class FlowEdge
    {
        private readonly int v; // edge source
        private readonly int w; // edge target
        private readonly double capacity; // capacity
        private double flow; // flow
        public FlowEdge(int v, int w, double capacity)
        {
            this.v = v;
            this.w = w;
            this.capacity = capacity;
            this.flow = 0.0;
        }

        public int from()
        {
            return v;
        }

        public int to()
        {
            return w;
        }

        public double Capacity()
        {
            return capacity;
        }

        public double Flow()
        {
            return flow;
        }

        public int other(int vertex)
        {
            if (vertex == v) return w;
            else if (vertex == w) return v;
            else throw new Exception("Inconsistent edge");
        } 

        public double residualCapacityTo(int vertex)
        {
            if (vertex == v)
                return flow;
            else if (vertex == w)
                return capacity - flow;
            else
                throw new Exception("Inconsistent edge");
        }
        public void addResidualFlowTo(int vertex, double delta)
        {
            if (vertex == v)
                flow -= delta;
            else if (vertex == w)
                flow += delta;
            else
                throw new Exception("Inconsistent edge");
        }

        public override string ToString()
        {
            return string.Format("{0}->{1} {2} {3}", v, w, capacity, flow);
        }
    }
}