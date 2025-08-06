using DemoConsoleTesting;

namespace DemoNUnitTesting
{
    public class Tests
    {
        private Calculator cal;

        [SetUp]
        public void Setup()
        {
             cal = new Calculator();
        }
        [Test]
        public void Add()
        {
            int res = cal.Add(3, 7);
            Assert.AreEqual(10, res);
        }
        [Test]
        public void Sub()
        {
            int diff = cal.Sub(7, 3);
            Assert.AreEqual(4, diff);
        }
        [Test]
        public void Mul()
        {
            int prod = cal.Prod(7, 3);
            Assert.AreEqual(21, prod);
        }
        [Test]
        public void Div()
        {
            double div = cal.Div(8, 2);
            Assert.AreEqual(4, div);
        }
        [TestCase(10,0)]
        [TestCase(10,12)]
       
        public void Divide_ByZero_ThrowsException(int a , int b)
        {
            if (b == 0)
            {
                Assert.Throws<DivideByZeroException>(() => cal.Div(a, b));
            }
            else
            {
                Assert.AreEqual((float)(a/b), cal.Div(a, b));
            }
        }

        [TestCase(2, 3, 5)]
        [TestCase(10, 5, 15)]
        public void Add_TestCases(int a, int b, int exp)
        {
            int result = cal.Add(a, b);
            Assert.AreEqual(exp, result);
        }

    }
}