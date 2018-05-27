using System;
using System.Collections.Generic;
using System.Text;

public class RoyalGuard : Subordinate
{

    public RoyalGuard(string name) : base(name, "defending",3)
    {
    }

    public override void ReactToAttack()
    {
        if(this.IsAlive)
        Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
    }
}
    