﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz12
{
    public class Refl
    {
        static void main(string[] args)
        {
            Console.WriteLine(Output());
            Console.WriteLine(AddInts(1, 2));
        }
        public static string Output()
        {
            return "Test-Output";
        }
        public static int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
