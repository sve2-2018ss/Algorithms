namespace SubStrinSearch
{
    public class BoyerMoore : AbstractSearch
    {
        private int[] right;
        private string pat;

        public BoyerMoore(string pat)
        {
            // Compute skip table.
            this.pat = pat;
            int M = pat.Length;
            int R = 256;
            right = new int[R];
            for (int c = 0; c < R; c++)
                right[c] = -1; // -1 for chars not in pattern
            for (int j = 0; j < M; j++) // rightmost position for
                right[pat[j]] = j; // chars in pattern
        }

        public int search(string txt)
        {
            // Search for pattern in txt.
            int N = txt.Length;
            int M = pat.Length;
            int skip;
            for (int i = 0; i <= N - M; i += skip)
            {
                NextIteration();
                // Does the pattern match the text at position i ?
                skip = 0;
                for (int j = M - 1; j >= 0; j--)
                    if (pat[j] != txt[i + j])
                    {
                        skip = j - right[txt[i + j]];
                        if (skip < 1) skip = 1;
                        break;
                    }
                if (skip == 0) return i; // found.
            }
            return N; // not found.
        }
    }
}