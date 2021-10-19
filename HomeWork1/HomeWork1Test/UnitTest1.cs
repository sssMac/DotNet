using HomeWork1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeWork1Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Sum_20_Plus_5_25_Returned()
        {
            string[] args = new string[] { "20", "+", "5" };
            var expected = Program.Main(args);
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void Dif_20_Minus_5_15_Returned()
        {
            string[] args = new string[] { "20", "-", "5" };
            var expected = Program.Main(args);
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void Prod_20_Multy_5_100_Returned()
        {
            string[] args = new string[] { "20", "*", "5" };
            var expected = Program.Main(args);
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void Priv_20_Divide_5_4_Returned()
        {
            string[] args = new string[] { "20", "/", "5" };
            var expected = Program.Main(args);
            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void Error_5_divide_a_1_Returned()
        {
            string[] args = new string[] { "5", "/", "a" };
            var expected = Program.Main(args);
            Assert.AreEqual(expected, 1);
        }

        [TestMethod]
        public void Erorr_20_symbol_5_2_Returned()
        {
            string[] args = new string[] { "20", "?", "5" };
            var expected = Program.Main(args);
            Assert.AreEqual(expected, 2);
        }

        [TestMethod]
        public void CalculatorNullResultTests()
        {
            Calculator calc = new Calculator();

            int val1 = 14;
            int val2 = 6;
            string operation = null;

            var res = calc.Calculate(val1, operation, val2);

            Assert.AreEqual(res, 0);
        }

    }
}