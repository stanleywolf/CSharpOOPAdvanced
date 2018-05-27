using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
    

{
    public T Type { get; set; }
    private IList<T> list;

    public T this[int index]
    {
        get { return this.list[index]; }
        set { this.list[index] = value; }
    }
    public Box(T type)
    {
        this.Type = type;
        this.list = new List<T>();
    }

    public Box()
    {
        this.list = new List<T>();
    }

    public void Add(T element)
    {
        this.list.Add(element);
    }

    public void SwapByIndex(int first, int second)
    {
        T temp = this.list[first];
        this.list[first] = this.list[second];
        this.list[second] = temp;

    }
    public override string ToString()
    {
        return $"{this.Type.GetType().FullName}: {this.Type}";
    }
}