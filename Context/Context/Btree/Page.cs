using System.Collections.Generic;

namespace Context
{
   /* public class Page<Key>
    {
        private List<Key> Keys;
        public bool bottom; 

        public Page(bool bottom)
        {
            this.bottom = bottom;
            Keys=new List<Key>();
        }// create and open a page

        public void close()
        {
            
        } //close a page

        public void add(Key key)
        {
            Keys.Add(key);
        }// put key into the(external) page

        public void add(Page<Key> p)
        {
            Keys.AddRange(p.Keys);
        }//open p and put an entry into this (internal) page that associates the smallest key in p with p

        public bool isExternal()
        {
            
        }//is this page external?

        public bool contains(Key key)
        {
            return Keys.Contains(key);
        } //is key in the page?

        public Page<Key> next(Key key)
        {
            
        }// the subtree that could contain the key

        public bool isFull()
        {
            
        } //has the page overflowed?

        public Page<Key> split()
        {
            
        } //move the highest-ranking half of the keys in the page to a new page

        IEnumerable<Key> keys()
        {
            return Keys;
        } //iterator for the keys on the page
    }*/
}