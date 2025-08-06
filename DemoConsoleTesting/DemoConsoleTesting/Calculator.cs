using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleTesting
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;

        public int Sub(int a, int b) => a - b;

        public int Prod(int a, int b) => a * b;

        public double Div(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return (double)a / b;
        }
    }

}
