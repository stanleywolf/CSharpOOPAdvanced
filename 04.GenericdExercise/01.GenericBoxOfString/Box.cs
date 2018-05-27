using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    
{
    public T Type { get; set; }

    
    public Box(T type)
    {
        this.Type = type;
    }

    public override string ToString()
    {
        return $"{this.Type.GetType().FullName}: {this.Type}";
    }
}