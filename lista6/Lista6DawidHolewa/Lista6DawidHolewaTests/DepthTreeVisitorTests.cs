using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lista6DawidHolewa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lista6DawidHolewa.Tests
{
    [TestClass()]
    public class DepthTreeVisitorTests
    {
        [TestMethod()]
        public void Test()
        {
            Tree tree = new TreeNode
            {
                Left = new TreeNode
                {
                    Left = new TreeLeaf(),
                    Right = new TreeNode
                    {
                        Left = new TreeLeaf(),
                        Right = new TreeLeaf()
                    }
                },
                Right = new TreeLeaf()

            };
            DepthTreeVisitor depthTreeVisitor = new DepthTreeVisitor();
            tree.Accept(depthTreeVisitor);
            Assert.AreEqual(3, depthTreeVisitor.Depth);

        }
        
    }
}