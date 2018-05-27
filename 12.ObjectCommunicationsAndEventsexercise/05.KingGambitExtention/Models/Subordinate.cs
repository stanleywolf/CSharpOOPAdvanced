using System;
using System.Collections.Generic;
using System.Text;

public abstract class Subordinate:ISubordinate
{
    public event SubordinateDeathEventHandler DeathEvent;

    public string Name { get; }
    public bool IsAlive { get; private set; }
    public int Hitpoints { get; private set; }
    public string Action { get; }

    protected Subordinate(string name, string action,int hitpoints)
    {
        this.Name = name;
        this.IsAlive = true;
        this.Action = action;
        this.Hitpoints = hitpoints;
    }
    public void Die()
    {
        this.IsAlive = false;
        if (this.DeathEvent != null)
        {
            this.DeathEvent.Invoke(this);
        }
    }
    public virtual void ReactToAttack()
    {
        if(this.IsAlive)
        Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
    }
    public void TakeDamage()
    {
        this.Hitpoints--;
        if (this.Hitpoints <= 0)
        {
            this.Die();
        }
    }
}