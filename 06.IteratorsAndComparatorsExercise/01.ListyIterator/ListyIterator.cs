using System;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{
    private IList<T> element;
    private int index = 0;
    public ListyIterator()
    {
        this.element = new List<T>();
    }

    public void Create(List<T> element)
    {
        this.element = element;
    }

    public bool Move()
    {
        if (this.index < this.element.Count - 1)
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
            if (this.element.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.element[this.index]);

            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    public bool HasNext()
    {
        if (this.index + 1 >= this.element.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Stop()
    {
        
    }
}