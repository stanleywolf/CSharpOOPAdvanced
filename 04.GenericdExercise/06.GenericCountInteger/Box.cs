using System;
using System.Collections.Generic;
using System.Text;

public class Box<T> 
    where T:IComparable<T>


{
    public int Count { get; private set; }
    private IList<T> list;

    public T this[int index]
    {
        get { return this.list[index]; }
        set { this.list[index] = value; }
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
    

    public int Compare(T element)
    {
        int count = 0;
        for (int i = 0; i < this.list.Count; i++)
        {
            T currentEl = this.list[i];
            if (currentEl.CompareTo(element) > 0)
            {
                count++;
            }
        }
        return count;
    }
}