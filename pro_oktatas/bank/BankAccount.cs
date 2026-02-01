using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_oktatas.bank
{
    public class InsufficientFundsException : Exception
    {
        private decimal balance;
        private decimal amount;
        public InsufficientFundsException(decimal balance, decimal amount)
            : base($"Balance is {balance} while amount is {amount}!")
        {
            this.balance = balance;
            this.amount = amount;
        }
    }

    public class BankAccount
    {
        private string accountNumber;
        private string ownerName;
        private List<Transaction> transactions;

        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                string trimmedValue = value.Trim();
                if (trimmedValue.Length < 6)
                    throw new ArgumentException("Account number must be at least 6 characters");
                accountNumber = trimmedValue;
            }
        }
        public string OwnerName
        {
            get { return ownerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Owner name cannot be empty");
                ownerName = value;
            }
        }
        public decimal Balance { get; private set; }
        public IReadOnlyList<Transaction> Transactions
        {
            get { return transactions; }
            private set { transactions = (List<Transaction>) value; }
        }

        public BankAccount(string accountNumber, string ownerName, decimal openingBalance)
        {
            if (openingBalance < 0)
                throw new ArgumentException("Opening balance cannot be less than 0!");
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = openingBalance;
            var initialTransactions = new List<Transaction>();
            if (openingBalance > 0)
                initialTransactions.Add(new Transaction(DateTime.Now, openingBalance, "Opening transaction"));
            Transactions = initialTransactions;
        }

        public void Deposit(decimal amount, string note)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0!");
            Balance += amount;
            transactions.Add(new Transaction(DateTime.Now, amount, note));
        }

        public void Withdraw(decimal amount, string note)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than 0!");
            if (amount > Balance)
                throw new InsufficientFundsException(Balance, amount);
            Balance -= amount;
            transactions.Add(new Transaction(DateTime.Now, -amount, note));
        }
    }
}
