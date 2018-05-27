using System;
using System.Collections.Generic;
using System.Text;

public class NameChangeEventArgs : EventArgs
{
    public string  Name { get; set; }

    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }
}