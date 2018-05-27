using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PersonComparatorOne:IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            result = (int)char.ToLower(x.Name[0]) - (int)char.ToLower(y.Name[0]);
        }
        return result;
    }
}