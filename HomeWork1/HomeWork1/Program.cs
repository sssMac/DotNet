using System;

namespace HomeWork1
{
    public static class Program
    {
        static public int Main(string[] args)
        {
            var parseResult = Parser.TryParseArguments(
                args, 
                out var val1, 
                out var operation,
                out var val2);
            
            if (parseResult != 0)
            {
                return parseResult;
            }

            Calculator calc = new Calculator();

            var result = calc.Calculate(val1,operation, val2);

            Console.WriteLine($"{args[0]}{args[1]}{args[2]}={result}");
            return 0;
        }
    }
}