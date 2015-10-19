using System;

namespace Context
{
    /*public class BTreeSET<Key>
    {
        private Page<Key> root = new Page<Key>(true);

        public BTreeSET(Key sentinel)
        {
            put(sentinel);
        }

        public void put(Key key)
        {
            root.add(key);
        }

        public void put(Page<Key> page, Key key)
        {
            page.add(key);
        }

        public bool contains(Key key)
        {
            return contains(root, key);
        }

        private bool contains(Page<Key> h, Key key)
        {
            if (h.isExternal())
                return h.contains(key);
            return contains(h.next(key), key);
        }

        public void add(Key key)
        {
            put(root, key);
            if (root.isFull())
            {
                Page<Key> lefthalf = root;
                Page<Key> righthalf = root.split();
                root = new Page<Key>(false);
                root.add(lefthalf);
                root.add(righthalf);
            }
        }

        public void add(Page<Key> h, Key key)
        {
            if (h.isExternal())
            {
                h.add(key);
                return;
            }
            Page<Key> next = h.next(key);
            put(next, key);
            if (next.isFull())
                h.add(next.split());
            next.close();
        }
        
    }*/
}