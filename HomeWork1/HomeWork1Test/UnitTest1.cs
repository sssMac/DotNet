using HomeWork1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProgramTests()
        {
            string[][] args = new string[][]
            {
                new string[] {"20", "+", "5"},
                new string[] {"20", "-", "5"},
                new string[] {"20", "*", "5"},
                new string[] {"20", "/", "5"},
                new string[] {"a", "/", "5"},
                new string[] {"20", "?", "5"},

            };

            for (int i = 0; i < 4; i++)
            {
                var expected0 = Program.Main(args[i]);
                Assert.AreEqual(expected0,0);
            }
            
            var expected1 = Program.Main(args[4]);
            Assert.AreEqual(expected1,1);
            
            var expected2 = Program.Main(args[5]);
            Assert.AreEqual(expected2, 2);
            
        }
        
        [TestMethod]
        public void CalculatorNullResaultTests()
        {
            Calculator calc = new Calculator();

            int val1 = 14;
            int val2 = 6;
            string operation = null;

            var res = calc.Calculate(val1, operation, val2);
            
            Assert.AreEqual(res,0);
        }
        
    }
    
}