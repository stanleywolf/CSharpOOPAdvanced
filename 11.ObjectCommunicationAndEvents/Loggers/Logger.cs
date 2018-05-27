using System;
using System.Collections.Generic;
using System.Text;

public abstract class Logger : IHendler
{
    private IHendler successor;

    public abstract void Handle(LogType logType, string massage);
    

    public void SetSuccessor(IHendler handler)
    {
        this.successor = successor;
    }

    protected void PassSuccessor(LogType type, string massage)
    {
        if (this.successor != null)
        {
            this.successor.Handle(type, massage);
        }
    }
}