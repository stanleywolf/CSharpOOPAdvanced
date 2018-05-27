using System;
using System.Collections.Generic;
using System.Text;
public delegate void GetAttackEventHandler();

public interface IAttackable
{
    event GetAttackEventHandler GetAttackEvent;
    void GetAttacket();
}