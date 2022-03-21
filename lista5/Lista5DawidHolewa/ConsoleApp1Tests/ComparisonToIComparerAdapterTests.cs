using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ComparisonToIComparerAdapterTests
    {

        static int IntComparer(int x, int y)
        {
            return x.CompareTo(y);
        }

        [TestMethod()]
        public void ComparisonToIComparerAdapterTest()
        {
            ArrayList b = new ArrayList() { 1, 5, 3, 3, 2, 4, 3 };
            ArrayList a = new ArrayList() { 1, 5, 3, 3, 2, 4, 3 };
            a.Sort(new ComparisonToIComparerAdapter(IntComparer));
            b.Sort();
            Assert.AreEqual(a[2], b[2]);
            Assert.AreEqual(a[1], b[1]);
            Assert.AreEqual(a[3], b[3]);
            Assert.AreEqual(a[4], b[4]);
            Assert.AreEqual(a[5], b[5]);

        }




    }
}