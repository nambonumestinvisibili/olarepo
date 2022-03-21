using Lista6DawidHolewa;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lista6DawidHolewa.Tests
{
    [TestClass()]
    public class Visitor2Tests
    {
        PrintExpressionVisitor pev;

        [TestInitialize()]
        public void Init()
        {
            pev = new PrintExpressionVisitor();
        }

        [TestMethod()]
        public void IfTest()
        {
            int x = 11;
            ConditionalExpression cond = Expression.Condition(
                    Expression.Constant(x > 10),
                    Expression.Constant("x is greater than 10"),
                    Expression.Constant("x is less or equal than 10")
            );

            pev.Visit(cond);
            Assert.IsTrue(true);
            
        }

        [TestMethod()]
        public void SwitchTest()
        {
            var switchValue = Expression.Constant(11);

            SwitchExpression switchExpr =
    Expression.Switch(
        switchValue,
        Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("Default")
                ),
        new SwitchCase[] {
            Expression.SwitchCase(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("First")
                ),
                Expression.Constant(1)
            ),
            Expression.SwitchCase(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("Second")
                ),
                Expression.Constant(2)
            )
        }
    );

            pev.Visit(switchExpr);
            Assert.IsTrue(true);

        }

        [TestMethod()]
        public void Unary()
        {
            System.Linq.Expressions.UnaryExpression typeAsExpression =
    System.Linq.Expressions.Expression.TypeAs(
        System.Linq.Expressions.Expression.Constant(34, typeof(int)),
        typeof(int?));

            pev.Visit(typeAsExpression);

        }
    }
}
