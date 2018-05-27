using System;
using System.Collections.Generic;
using System.Text;

public abstract class Subordinate:ISubordinate
{
    public string Name { get; }
    public bool IsAlive { get; private set; }
    public string Action { get; }

    protected Subordinate(string name, string action)
    {
        this.Name = name;
        this.IsAlive = true;
        this.Action = action;
    }
    public void Die()
    {
        this.IsAlive = false;
    }
    public virtual void ReactToAttack()
    {
        if(this.IsAlive)
        Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
    }
}