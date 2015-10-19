using System;

namespace Context
{
    /*public class CollisionSystem
    {
        private class Event : IComparable<Event>
        {
            public readonly double time;
            public readonly Particle a, b;
            private readonly int countA, countB;

            public Event(double t, Particle a, Particle b)
            { // Create a new event to occur at time t involving a and b.
                this.time = t;
                this.a = a;
                this.b = b;
                if (a != null) countA = a.count(); else countA = -1;
                if (b != null) countB = b.count(); else countB = -1;
            }
            public int CompareTo(Event that)
            {
                if (this.time < that.time) return -1;
                else if (this.time > that.time) return +1;
                else return 0;
            }
            public bool isValid()
            {
                if (a != null && a.count() != countA) return false;
                if (b != null && b.count() != countB) return false;
                return true;
            } 
        }
        private PriorityQueue<Event> pq; // the priority queue
        private double t = 0.0; // simulation clock time
        private Particle[] particles; // the array of particles

        public CollisionSystem(Particle[] particles)
        {
            this.particles = particles;
        }

        private void predictCollisions(Particle a, double limit)
        {
             
        }
        public void redraw(double limit, double Hz)
        { // Redraw event: redraw all particles.
            StdDraw.clear();
            for (int i = 0; i < particles.Length; i++)
                particles[i].draw();
            StdDraw.show(20);
            if (t < limit)
                pq.Insert(new Event(t + 1.0 / Hz, null, null));
        }

        public void simulate(double limit, double Hz)
        {
            pq = new PriorityQueue<Event>();
            for (int i = 0; i < particles.Length; i++)
                predictCollisions(particles[i], limit);
            pq.Insert(new Event(0, null, null)); // Add redraw event.
            while (!pq.isEmpty())
            { // Process one event to drive simulation.
                Event ev = pq.Del();
                if (!ev.isValid()) continue;
                for (int i = 0; i<particles.Length; i++)
                    particles[i].move(ev.time - t); // Update particle positions
                t = ev.time; // and time.
                Particle a = ev.a, b = ev.b;
                if (a != null && b != null) a.bounceOff(b);
                else if (a != null && b == null) a.bounceOffHorizontalWall();
                else if (a == null && b != null) b.bounceOffVerticalWall();
                else if (a == null && b == null) redraw(limit, Hz);
                predictCollisions(a, limit);
                predictCollisions(b, limit);
            }
    }
    }*/
}