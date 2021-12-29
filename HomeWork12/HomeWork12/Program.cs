using System;
using BenchmarkDotNet.Running;

namespace HomeWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
