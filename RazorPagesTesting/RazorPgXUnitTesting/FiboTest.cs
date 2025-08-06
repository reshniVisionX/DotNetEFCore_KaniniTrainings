using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPgXUnitTesting
{
    using RazorPagesTesting.Repository;
    using Xunit;

    public class FibonacciGeneratorTests
    {
        [Fact]
        public void GetFibonacci_Of5_Returns5()
        {
            var fib = new FibonacciGenerator();
            int result = fib.GetFibonacci(5);
            Assert.Equal(5, result);
        }

        [Fact]
        public void GetFibonacci_Of0_Returns0()
        {
            var fib = new FibonacciGenerator();
            int result = fib.GetFibonacci(0);
            Assert.Equal(0, result);
        }
    }
}