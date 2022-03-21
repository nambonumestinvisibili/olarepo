using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lista6DawidHolewa
{
    public class PrintExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(System.Linq.Expressions.BinaryExpression expression)
        {
            
            Console.WriteLine("{0} {1} {2}",
            expression.Left, expression.NodeType, expression.Right);
            return base.VisitBinary(expression);
        }
        protected override Expression VisitLambda<T>(System.Linq.Expressions.Expression<T> expression)
        {
            Console.WriteLine("{0} -> {1}",
            expression.Parameters.Aggregate(string.Empty, (a, e) => a += e),
            expression.Body);
            return base.VisitLambda<T>(expression);
        }

        protected override SwitchCase VisitSwitchCase(SwitchCase node)
        {
            Console.WriteLine("Switch Case Test Values");
            node.TestValues.ToList().ForEach(x => {
                Console.Write("{0}, ", x);
            });
            return base.VisitSwitchCase(node);
        }

        protected override Expression VisitConditional(ConditionalExpression conditionalExpression)
        {
            Console.WriteLine("Conditional Expression to be tested: {0}", conditionalExpression.ToString());
            return base.VisitConditional(conditionalExpression);
        }

        protected override Expression VisitUnary(System.Linq.Expressions.UnaryExpression unaryExpr)
        {
            Console.WriteLine("{0}", unaryExpr.ToString());
            return base.VisitUnary(unaryExpr);
        }
    }

}
