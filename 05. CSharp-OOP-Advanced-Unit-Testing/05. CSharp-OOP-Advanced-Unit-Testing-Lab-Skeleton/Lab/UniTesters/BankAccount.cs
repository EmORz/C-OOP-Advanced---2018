using System;

namespace UniTesters
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            amount++;
            this.Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (this.Balance<amount)
            {
                throw  new Exception("Insuffience funds");
            }
            this.Balance -= amount;
        }

    }
}