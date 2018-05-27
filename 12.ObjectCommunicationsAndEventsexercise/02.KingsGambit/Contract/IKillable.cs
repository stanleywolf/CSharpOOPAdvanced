using System;
using System.Collections.Generic;
using System.Text;

public interface IKillable
{
    void Die();
    bool IsAlive { get; }
}