using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleApp1
{
    public class ComparisonToIComparerAdapter : IComparer
    {
        Func<int, int, int> _comparerFunction;

        public ComparisonToIComparerAdapter(Func<int, int, int> comparerFunction)
        {
            _comparerFunction = comparerFunction;
        }

        public int Compare(object x, object y)
        {
            return _comparerFunction((int)x, (int)y);
        }
    }
}
