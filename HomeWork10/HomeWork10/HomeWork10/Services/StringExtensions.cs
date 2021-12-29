using System.Collections.Generic;

namespace HomeWork10.Services
{
    public static class StringExtensions
    {
        public static string LeadToCorrectView(this string expression)
        {
            return expression.ToLower()
                .Replace("plus", "+")
                .Replace("minus", "-")
                .Replace("divide", "/")
                .Replace("multiply", "*")
                .Replace("lb", "(")
                .Replace("rb", ")");
        }

        public static IEnumerable<string> ParseBySpace(this string expression)
        {
            return expression.Split();
        }
        
        public static bool IsOperation(this string arg)
        {
            return arg is "+" or "-" or "/" or "*";
        }
    }
}