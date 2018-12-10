using System;
using NUnit.Framework;
using UniTesters;

namespace UniTestersTests
{
    public class BankAccountTests
    {
        [Test]

        public void DepositShouldIncreaseBalance()
        {
            var bankAccount = new BankAccount();
            bankAccount.Deposit(10);
            Assert.That(bankAccount.Balance, Is.EqualTo(10));
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(-10)]

        public void WithdrawThrowExceptionInsuffienceFunds(int amount)
        {
            var bankAccount = new BankAccount();
            bankAccount.Withdraw(10);
            Assert.Throws<Exception>(() => bankAccount.Withdraw(10));
        }
    }
}
