using System;
using System.Collections.Generic;
using System.Linq;

namespace Priority_Queues
{
    public class Stack<T> where T : IComparable<T>
    {
        private List<T> stack;

        public Stack()
        {
            stack=new List<T>();
        }

        public bool isEmpty()
        {
            return stack.Count == 0;
        } 

        public void push(T p)
        {
            stack.Add(p);
        }

        public T pull()
        {
            T temp = stack.Last();
            stack.Remove(temp);
            return temp;
        }

    }
}