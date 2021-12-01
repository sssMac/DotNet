﻿using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeWork10.Services
{
    public class CalculatorVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var first = Task.Run(() => Visit(node.Left));
            var second = Task.Run(() => Visit(node.Right));
            Task.Delay(1000).GetAwaiter().GetResult();
            Task.WhenAll(first, second);

            var firstResult =(ConstantExpression) first.Result;
            var secondResult = (ConstantExpression) second.Result;

            var val1 = (double) firstResult.Value;
            var val2 = (double) secondResult.Value;

            var res = node.NodeType switch
            {
                ExpressionType.Add        => val1 + val2,
                ExpressionType.Subtract   => val1 - val2,
                ExpressionType.Multiply   => val1 * val2,
                ExpressionType.Divide     => val1 / val2,
            };

            return Expression.Constant(res);
        }
    }
}