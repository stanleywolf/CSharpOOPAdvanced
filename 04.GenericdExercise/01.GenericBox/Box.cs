using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T type;

    public Box(T type)
    {
        this.type = type;
    }
    public override string ToString()
    {
        return $"{this.type.GetType().FullName}: {this.type}";
    }
}