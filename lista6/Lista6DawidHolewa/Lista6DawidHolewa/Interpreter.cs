using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lista6DawidHolewa
{
    public class Context
    {
        private Dictionary<string, bool> _evaluation = new Dictionary<string, bool>();
        public bool GetValue(string variableName)
        {
            if (_evaluation.ContainsKey(variableName))
            {
                return _evaluation[variableName];
            }
            else
            {
                throw new Exception("Variable does not exist");
            }
        }

        public void SetValue(string variableName, bool value)
        {
            _evaluation.Add(variableName, value);
        }
    }

    public interface AbstractExpression
    {
        bool Interpret(Context context);
    }

    public class Variable : AbstractExpression
    {
        public string Identifier;

        public Variable(string identifier)
        {
            Identifier = identifier;
        }

        public bool Interpret(Context context)
        {
            return context.GetValue(Identifier);
        }
    }

    public class ConstExpression : AbstractExpression
    {
        public bool Value;

        public ConstExpression(bool value)
        {
            Value = value;
        }

        public bool Interpret(Context context)
        {
            return Value;
        }
    }

    public abstract class BinaryExpression : AbstractExpression
    {
        protected AbstractExpression Left;
        protected AbstractExpression Right;
        protected Expression<Func<bool, bool, bool>> Operation;

        protected BinaryExpression(AbstractExpression left, AbstractExpression right)
        {
            Left = left;
            Right = right;
        }

        public bool Interpret(Context context)
        {
            Func<bool, bool, bool> deleg = Operation.Compile();
            return deleg(Left.Interpret(context), Right.Interpret(context));
        }
    }



    public class DisjunctionExpression : BinaryExpression
    {
        public DisjunctionExpression(AbstractExpression expr, AbstractExpression expr2) : base(expr, expr2)
        {
            Operation = (x, y) => x || y;          
        }
    }

    public class ConjunctionExpression : BinaryExpression
    {
        public ConjunctionExpression(AbstractExpression expr, AbstractExpression expr2) : base(expr, expr2)
        {
            Operation = (x, y) => x && y;
        }
    }

    public class UnaryExpression : AbstractExpression
    {
        protected AbstractExpression Child;
        protected Expression<Func<bool, bool>> Operation;

        public UnaryExpression(AbstractExpression child)
        {
            Child = child;
        }

        public bool Interpret(Context context)
        {
            var deleg = Operation.Compile();
            return deleg(Child.Interpret(context));
        }
    }

    public class NegationExpression : UnaryExpression
    {
        public NegationExpression(AbstractExpression expr) : base(expr)
        {
            Operation = (x) => !x;
        }
    }
}
