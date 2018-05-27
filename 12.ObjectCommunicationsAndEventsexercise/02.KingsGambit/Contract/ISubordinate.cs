using System;

public interface ISubordinate:INameble,IKillable
{
    string Action { get; }
    void ReactToAttack();
}