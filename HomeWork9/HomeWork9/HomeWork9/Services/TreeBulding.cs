﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HomeWork9.Services
{
    public  class TreeBulding
    {
        
        public static Dictionary<string, byte> Priority = new()
        {
            {"-", 1},
            {"+", 1},
            {"/", 2},
            {"*", 2}
        };
        
        public static Expression GetExepressionTree(string expression)
        {
            
            var outputStack = new Stack<Expression>();
            var operationStack = new Stack<string>();
            try
            {
                var tokens = expression
                    .LeadToCorrectView()
                    .ParseBySpace();
                
                foreach (var token in tokens)
                {
                    if (double.TryParse(token, out var number))
                    {
                        outputStack.Push(Expression.Constant(number));
                    }
                    else if (token.IsOperation())
                    {
                        while (operationStack.Count != 0 && operationStack.Peek() != "(" && Priority[operationStack.Peek()] >= Priority[token])
                        {
                            GenerateExpression(operationStack.Pop(), outputStack);
                        }
                        
                        operationStack.Push(token);
                    }
                    else if (token == "(")
                    {
                        operationStack.Push(token);
                    }
                    else if (token == ")")
                    {
                        var op = operationStack.Pop();
                        while (op != "(")
                        {
                            GenerateExpression(op, outputStack);
                            op = operationStack.Pop();
                        }
                    }
                }

                foreach (var op in operationStack)
                {
                    GenerateExpression(op, outputStack);
                }
                
                return outputStack.Pop();
            }
            catch (Exception)
            {
                Expression<Func<string>> e = () => "Error";
                return e;
            }
        }
        
        public static void GenerateExpression(string op, Stack<Expression> stack)
        {
            var val1 = stack.Pop();
            var val2 = stack.Pop();
            switch (op)
            {
                case "+":
                    stack.Push(Expression.Add(val2, val1));
                    break;
                case "-":
                    stack.Push(Expression.Subtract(val2, val1));
                    break;
                case "*":
                    stack.Push(Expression.Multiply(val2, val1));
                    break;
                case "/":
                    stack.Push(Expression.Divide(val2, val1));
                    break;
            }
        }
    }
}