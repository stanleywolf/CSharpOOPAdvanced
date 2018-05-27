using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command:IExecutable
{
    private string[] data;

    protected string[] Data { get { return this.data; } }

    protected Command(string[] data)
    {
        this.data = data;
    }
    public abstract void Execute();

}