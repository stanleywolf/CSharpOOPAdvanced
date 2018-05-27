using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T>:IEnumerable<T>
{
    private IList<T> elements;
    public int Count { get; private set; }

    public Stack()
    {
        this.elements = new List<T>();
        this.Count = 0;
    }

    public void Push(T element)
    {
        this.elements.Add(element);
        this.Count++;
    }

    public void Pop()
    {
        if (this.elements.Count == 0)
        {
            Console.WriteLine("No elements");
        }
        else
        {
            var lastElement = this.elements.Count - 1;
            this.elements.RemoveAt(lastElement);
            this.Count--;
        }
        
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public void PrintElement()
    {
        for (int j = this.Count- 1; j >= 0; j--)
        {
            Console.WriteLine(this.elements[j]);
        }
    }
}