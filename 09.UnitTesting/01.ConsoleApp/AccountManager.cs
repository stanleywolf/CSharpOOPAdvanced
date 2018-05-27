using System;
using System.Collections.Generic;
using System.Text;

public class AccountManager : IAccountManager
{
    private BankAccount bankAccount;

    public AccountManager(BankAccount bankAccount)
    {
        this.bankAccount = bankAccount;
    }

    public BankAccount Account { get; private set; }

    public int GetBalanceInCents()
    {
        return Account.Balance;
    }
}