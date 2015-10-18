namespace SubStrinSearch
{
    public class KMP
    {
        private string pat;
        private int[,]dfa;

        public KMP(string pat)
        {
            // Build DFA from pattern.
            this.pat = pat;
            int M = pat.Length;
            int R = 256;
            dfa = new int[R,M];
            dfa[pat[0],0]= 1;
            for (int X = 0, j = 1; j < M; j++)
            {
                // Compute dfa[][j].
                for (int c = 0; c < R; c++)
                    dfa[c,j] = dfa[c,X]; // Copy mismatch cases.
                dfa[pat[j],j] = j + 1; // Set match case.
                X = dfa[pat[j],X]; // Update restart state.
            }
        }

        public int search(string txt)
        {
            // Simulate operation of DFA on txt.
            int i, j, N = txt.Length, M = pat.Length;
            for (i = 0, j = 0; i < N && j < M; i++)
                j = dfa[txt[i],j];
            if (j == M) return i - M; // found (hit end of pattern)
            else return N; // not found (hit end of text)
        }
    }
}