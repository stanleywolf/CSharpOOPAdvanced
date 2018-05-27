using System;
using System.Collections.Generic;
using System.Text;

public class AttackComand:ICommand
{
    private IAttacker attacker;

    public AttackComand(IAttacker attacker)
    {
        this.attacker = attacker;
    }
    public void Execute()
    {
        this.attacker.Attack();
    }
}