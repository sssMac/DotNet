using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWork10.Services;

namespace HomeWork10.Controllers
{
    public class Calculator : Controller
    {
        private static readonly Expression<Func<string>> Error = () => "Error";
        [HttpGet]
        public string Calculate(string expression)
        {
            var exp = TreeBulding.GetExepressionTree(expression);
            var res = exp == Error ? Error.ToString() : new CalculatorVisitor().Visit(exp).ToString();
            return res;
        }
    }
}