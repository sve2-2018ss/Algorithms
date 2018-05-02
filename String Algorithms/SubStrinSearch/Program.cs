using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubStrinSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "Where live Masha and Bear ?";
            string pat = "Masha";

            int point = BFsearch(pat, str);
            int AltPoint = AltBFsearch(pat, str);
            int KMPpoint = KMPsearch(pat, str);
            int BMpoint = BMsearch(pat, str);

            Console.WriteLine("Where \"{0}\" in \"{1}\" :\n" +
                              "\nBrute-force: {2}\n" +
                              "\nAlternative Brute-force: {3}\n" +
                              "\nKnuth-Morris-Pratt: {4}\n" +
                              "\nBoyer-Moore: {5}\n" +
                              "\nRabin-Karp: {6}\n"
                              , pat,str,point,AltPoint,KMPpoint,BMpoint,RabinKarp.Rabina(pat,str));

            Console.ReadKey();
        }

        public static int BFsearch(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;
            for (int i = 0; i <= N - M; i++)
            {
                int j;
                for (j = 0; j < M; j++)
                    if (txt[i + j] != pat[j])
                        break;
                if (j == M) return i; // found
            }
            return N; // not found
        }

        public static int AltBFsearch(string pat, string txt)
        {
            int j, M = pat.Length;
            int i, N = txt.Length;
            for (i = 0, j = 0; i < N && j < M; i++)
            {
                if (txt[i] == pat[j]) j++;
                else
                {
                    i -= j;
                    j = 0;
                }
            }
            if (j == M)
                return i - M; // found
            else return N; // not found
        }

        public static int KMPsearch(string pat, string txt)
        {
            KMP kmp=new KMP(pat);
            return kmp.search(txt);
        }

        public static int BMsearch(string pat, string txt)
        {
            BoyerMoore bm = new BoyerMoore(pat);
            return bm.search(txt);
        }
    }
    
}
