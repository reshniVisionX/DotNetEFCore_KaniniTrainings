using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleTesting
{
    public class ATM
    {
        private Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();
        public ATM() { }
        public void CreateAccount(string accountNumber, decimal initialBalance)
        {
            if (accounts.ContainsKey(accountNumber))
                throw new InvalidOperationException("Account already exists.");

            accounts[accountNumber] = initialBalance;
        }

        public decimal GetBalance(string accountNumber)
        {
            if (!accounts.ContainsKey(accountNumber))
                throw new ArgumentException("Invalid account.");

            return accounts[accountNumber];
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            accounts[accountNumber] += amount;
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (accounts[accountNumber] < amount)
                throw new InvalidOperationException("Insufficient funds.");

            accounts[accountNumber] -= amount;
        }
    }
}
