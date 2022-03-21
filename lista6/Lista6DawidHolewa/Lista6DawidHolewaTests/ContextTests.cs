using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lista6DawidHolewa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lista6DawidHolewa.Tests
{
    [TestClass()]
    public class ContextTests
    {
        Context context;

        [TestInitialize()]
        public void Init()
        {
            context = new Context();
            context.SetValue("x", true);
            context.SetValue("y", false);
        }

        [TestMethod()]
        public void NegationTest()
        {
            AbstractExpression exp = new NegationExpression(new Variable("x"));
            Assert.IsFalse(exp.Interpret(context));
        }

        [TestMethod()]
        public void VariableTest()
        {
            var expr = new Variable("x");
            Assert.IsTrue(expr.Interpret(context));
        }

        [TestMethod()]
        public void ConstTest()
        {
            Assert.IsFalse(new ConstExpression(false).Interpret(context));
        }

        [TestMethod()]
        public void DisjunctionTest()
        {
            var e1 = new Variable("y");
            Assert.IsFalse(new DisjunctionExpression(e1, new ConstExpression(false)).Interpret(context));
            Assert.IsTrue(new DisjunctionExpression(e1, new ConstExpression(true)).Interpret(context));
        }

        [TestMethod()]
        public void ConjunctionTest()
        {
            var e1 = new Variable("x");
            Assert.IsFalse(new ConjunctionExpression(e1, new ConstExpression(false)).Interpret(context));
            Assert.IsTrue(new ConjunctionExpression(e1, new ConstExpression(true)).Interpret(context));
        }

        [TestMethod()]
        public void BadVariableTest()
        {
            var e1 = new Variable("z");
            Assert.ThrowsException<Exception>(() =>
           {
               e1.Interpret(context);
           }); 
        }
    }
}