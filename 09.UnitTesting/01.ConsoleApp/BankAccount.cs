using System;
using System.Collections.Generic;
using System.Text;

public class BankAccount
{
    public int Balance { get; set; }

    public BankAccount(int initialBalance)
    {
        this.Balance = initialBalance;
    }

    public BankAccount()
    {
        
    }
    public void Deposit(int amount)
    {
        this.Balance += amount;
    }

    public void Withdrow(int amount)
    {
        if (this.Balance < amount)
        {
            throw new Exception("No money");
        }
        this.Balance -= amount;
    }
}