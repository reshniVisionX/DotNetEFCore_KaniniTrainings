using DemoConsoleTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaXUnitTesting
{
    public class Atmtest
    {
        [Fact]
        public void CreateAccount()
        {
            ATM atm = new ATM();
            atm.CreateAccount("101", 1000);

            Assert.Equal(1000, atm.GetBalance("101"));
        }

        [Fact]
        public void Deposit()
        {
            ATM atm = new ATM();
            atm.CreateAccount("102", 500);
            atm.Deposit("102", 200);

            Assert.Equal(700, atm.GetBalance("102"));
        }

        [Fact]
        public void Withdraw()
        {
            ATM atm = new ATM();
            atm.CreateAccount("103", 800);
            atm.Withdraw("103", 300);

            Assert.Equal(500, atm.GetBalance("103"));
        }

        [Fact]
        public void Withdraw_InsufficientFunds()
        {
            ATM atm = new ATM();
            atm.CreateAccount("104", 100);

            Assert.Throws<InvalidOperationException>(() => atm.Withdraw("104", 200));
        }

        [Fact]
        public void Deposit_NegativeAmount()
        {
            ATM atm = new ATM();
            atm.CreateAccount("105", 100);

            Assert.Throws<ArgumentException>(() => atm.Deposit("105", -50));
        }

        [Fact]
        public void Withdraw_NegativeAmount()
        {
            ATM atm = new ATM();
            atm.CreateAccount("106", 300);

            Assert.Throws<ArgumentException>(() => atm.Withdraw("106", -100));
        }

        [Fact]
        public void CreateAccount_Exists()
        {
            ATM atm = new ATM();
            atm.CreateAccount("107", 100);

            Assert.Throws<InvalidOperationException>(() => atm.CreateAccount("107", 200));
        }

        [Fact]
        public void GetBalance_InvalidAccount()
        {
            ATM atm = new ATM();

            Assert.Throws<ArgumentException>(() => atm.GetBalance("200"));
        }
    }
}
