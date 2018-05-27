using System;
using System.Collections.Generic;
using System.Text;

public class King : IKing
{
    public event GetAttackEventHandler GetAttackEvent;

    public string Name { get; }

    public King(string name, ICollection<ISubordinate> subordinates)
    {
        this.Name = name;
        this.subordinates = subordinates;
    }
    private ICollection<ISubordinate> subordinates;
    public IReadOnlyCollection<ISubordinate> Subordinates => (IReadOnlyCollection<ISubordinate>) subordinates;
    
    public void GetAttacket()
    {
        Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");
        if (this.GetAttackEvent != null)
        {
            this.GetAttackEvent.Invoke();
        }
    }
    public void AddSubordinated(ISubordinate subordinate)
    {
        this.subordinates.Add(subordinate);
        this.GetAttackEvent += subordinate.ReactToAttack;
    }
}