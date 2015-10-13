using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] strs=new string[] {"sdfssd","sdfsdfsdadf","wr24rtgrgsfa","134nvk1"};

            string[] strs=new string[] {"5","3","4","2","0","1"};

            Helpers.Show(strs,"Before sort");
            
            #region Elementary Sorts
            //Helpers.CompareElementarySorts(strs);
            //Selection.Sort(strs);
            //Insertion.Sort(strs);
            //Shell.Sort(strs);
            #endregion
            
            #region Merge Sorts
            //Helpers.CompareMergeSorts(strs);
            //Merge.TopDownSort(strs);
            //Merge.BottomUpSort(strs);
            #endregion
            
            #region Quick Sorts
            //Helpers.CompareQuickSorts(strs);
            //Quick.Sort(strs);
            //Quick3Way.Sort(strs);
            #endregion

            Helpers.Show(strs, "After sort");

            Console.ReadKey();
        }
    }
}
