﻿using System;
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

            Selection.Sort(strs);

            Helpers.Show(strs, "After sort");

            Console.ReadKey();
        }
    }
}