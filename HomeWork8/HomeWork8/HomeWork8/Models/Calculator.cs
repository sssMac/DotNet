using System;

namespace HomeWork8.Models

{
    public class Calculator : ICalculator
    {

        public double Add(double v1, double v2)
      {
          return v1 + v2;
      }

      public double Min(double v1, double v2)
      {
          return v1 - v2;
      }

      public double Div(double v1, double v2)
      {
          return v2 == 0 ? 0 :  v1 / v2;
      }

      public double Mul(double v1, double v2)
      {
          return v1 * v2;
      }
    }
}