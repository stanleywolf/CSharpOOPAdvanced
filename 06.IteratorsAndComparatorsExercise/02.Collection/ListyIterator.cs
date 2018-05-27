using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>:IEnumerable<T>
{
    private IList<T> elements;
    private int index = 0;
    public ListyIterator()
    {
        this.elements = new List<T>();
    }

    public void Create(List<T> element)
    {
        this.elements = element;
    }

    public bool Move()
    {
        if (this.index < this.elements.Count - 1)
        {
            this.index++;
            return true;
        }
        else
        {
        return false;
        }
    }

    public void Print()
    {
        try
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.elements[this.index]);

            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    public bool HasNext()
    {
        if (this.index + 1 >= this.elements.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void PrintAll()
    {
        Console.WriteLine(string.Join(" ",this.elements));
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
}