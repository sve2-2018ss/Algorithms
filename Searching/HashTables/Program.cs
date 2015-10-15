using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearProbingHashST<int, string> st = new LinearProbingHashST<int, string>();

            Console.WriteLine("Input Hash Table :");
            for (int i = 1; i <= 16; i++)
            {
                st.put(i, $"{char.ConvertFromUtf32(i + 64)}");
                Console.WriteLine("{0} {1}",i, $"{char.ConvertFromUtf32(i + 64)}");
            }
            Console.WriteLine("End Input Hash Table;");
            Console.Write("Find by Key :");
            Console.WriteLine("Value = {0}",st.get(int.Parse(Console.ReadLine())));
            //st.print();

            Console.ReadKey();
        }
    }

    
    public class LinearProbingHashST<Key, Value>
    {
        private int N=0; // number of key-value pairs in the table
        private int M; // size of linear-probing table
        private Key[] keys; // the keys
        private Value[] vals; // the values

        public void print()
        {
            Console.WriteLine("Hash\tKey\tValue");
            for(int i=0;i<M;i++)
                Console.WriteLine("{0}\t{1}\t{2}",hash(keys[i]),keys[i],vals[i]);
        }

        public LinearProbingHashST(int cap=16)
        {
            this.M = cap;
            keys = new Key[M];
            vals = new Value[M];
        }

        private int hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }
        
        private void resize(int cap)
        {
            LinearProbingHashST<Key, Value> t;
            t = new LinearProbingHashST<Key, Value>(cap);
            for (int i = 0; i < M; i++)
                if (keys[i] != null)
                    t.put(keys[i], vals[i]);
            keys = t.keys;
            vals = t.vals;
            M = t.M;
        }

        public void put(Key key, Value val)
        {
            if (N >= M / 2) resize(2 * M); 
            int i=N;
            /*for (i = hash(key); keys[i] != null; i = (i + 1) % M)
                if (keys[i].Equals(key)) 
                { 
                vals[i] = val; return; 
                }*/
            keys[i] = key;
            vals[i] = val;
            N++;
        }
        public Value get(Key key)
        {
            for (int i = hash(key); keys[i] != null; i = (i + 1) % M)
                if (keys[i].Equals(key))
                    return vals[i];
            return default(Value);
        }

        public void delete(Key key)
        {
            if (!contains(key)) return;
            int i = hash(key);
            while (!key.Equals(keys[i]))
                i = (i + 1) % M;
            keys[i] = default(Key);
            vals[i] = default(Value);
            i = (i + 1) % M;
            while (keys[i] != null)
            {
                Key keyToRedo = keys[i];
                Value valToRedo = vals[i];
                keys[i] = default(Key);
                vals[i] = default(Value);
                N--;
                put(keyToRedo, valToRedo);
                i = (i + 1) % M;
            }
            N--;
            if (N > 0 && N == M / 8) resize(M / 2);
        }

        private bool contains(Key key)
        {
            return keys.Contains(key);
        }
    }
}
