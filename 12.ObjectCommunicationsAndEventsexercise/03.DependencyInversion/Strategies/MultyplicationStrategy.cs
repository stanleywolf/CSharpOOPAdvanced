using System;
using System.Collections.Generic;
using System.Text;

public class MultyplicationStrategy:ICalculationStrategy
    {
        public int Calculate(int first, int second)
        {
            return first * second;
        }
    }
   