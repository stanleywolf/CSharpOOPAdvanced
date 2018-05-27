using System;
public delegate void SubordinateDeathEventHandler(object sender);
public interface ISubordinate:INameble,IKillable
{
    string Action { get; }
    void ReactToAttack();
    event SubordinateDeathEventHandler DeathEvent;
}