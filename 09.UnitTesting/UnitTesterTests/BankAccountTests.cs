using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTesterTests
{
    public class BankAccountTests
    {
        private BankAccount bankAccount;

        //[SetUp]
        //public void InitializeTest()
        //{
        //    bankAccount = new BankAccount();
        //}

        [Test]
        public void ConstructorSetBalance()
        {
            int initialBalance = 10;
            int expectedAmount = 10;

            var bancAccount = new BankAccount(initialBalance);
            Assert.That(bancAccount.Balance,Is.EqualTo(expectedAmount));
        }
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            var bankAccount = new BankAccount();
            bankAccount.Deposit(10);
            Assert.That(bankAccount.Balance, Is.EqualTo(10));
        }

        [Test]
        public void WithdrowThrowExeptonsIf()
        {
            var bankAccount = new BankAccount();
            bankAccount.Deposit(10);
            Assert.Throws<Exception>(() => bankAccount.Withdrow(11));
        }
    }
}
