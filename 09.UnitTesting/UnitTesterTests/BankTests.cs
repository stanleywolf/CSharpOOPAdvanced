using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;

public class BankTests
{
    [Test]
    public void GetAccountBalanceFotmatMoney()
    {
        //var bank = new Bank(new FakeAccountManager(10));
        var bankAccount = new BankAccount(10);
        var accountManager = new AccountManager(bankAccount);
        var bank = new Bank(accountManager);

        string expected = "10.00";
        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
    }

    [Test]
    public void GetAccountBalanceFotmatMoneyWithMockingLibrary()
    {
        var fakeAccountManager = new Mock<IAccountManager>();
        fakeAccountManager.Setup(m => m.GetBalanceInCents()).Returns(10);
        var bank = new Bank(fakeAccountManager.Object);

        string expected = "10.00";
        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
    }
    class FakeAccountManager:IAccountManager
    {
        private int centsToReturn;

        public FakeAccountManager(int centsToReturn)
        {
            this.centsToReturn = centsToReturn;
        }
        public int GetBalanceInCents()
        {
            return centsToReturn;
        }
    }
}