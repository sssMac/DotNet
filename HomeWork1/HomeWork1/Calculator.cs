﻿namespace HomeWork1
{
    public class Calculator
    {
        public int Calculate(int val1,string operation, int val2)
        {
            var result = operation switch
            {
                "+" => val1 + val2,
                "-" => val1 - val2,
                "*" => val1 * val2,
                "/" => val1 / val2,
                _ => 0
            };
            return result;
            
        }
    }
}