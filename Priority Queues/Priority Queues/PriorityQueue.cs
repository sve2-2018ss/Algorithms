using System;
using System.Collections.Generic;

namespace Priority_Queues
{
    public class PriorityQueue<T> where T:IComparable<T>
    {
        private List<T> queue;

        private int Max;
        private bool MaxOrMin;

        /// <summary>
        /// Priority Queue Constructor
        /// </summary>
        /// <param name="max">Max queue length</param>
        /// <param name="maxormin">if False - DelMax, if True - DelMin</param>
        public PriorityQueue(int max,bool maxormin=false)
        {
            queue=new List<T>();
            Max = max;
            MaxOrMin = maxormin;
        }

        public void Insert(T a)
        {
            queue.Add(a);
            IfOverRange();
        }

        public bool isEmpty()
        {
            return queue.Count == 0;
        }

        private void IfOverRange()
        {
            if (queue.Count == Max + 1)
                Del();
        }

        public T Del()
        {
            return MaxOrMin ? DelMin() : DelMax();
        }

        private T DelMax()
        {
            T max = queue[0];
            foreach (var q in queue)
                if (q.CompareTo(max) > 0)
                    max = q;
            queue.Remove(max);
            return max;
        }

        private T DelMin()
        {
            T min = queue[0];
            foreach (var q in queue)
                if (q.CompareTo(min) < 0)
                    min = q;
            queue.Remove(min);
            return min;
        }
    }
}