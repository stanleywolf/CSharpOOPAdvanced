using System;
using System.Collections.Generic;
using System.Text;

class PersonEqComparer:IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.CompareTo(y) == 0;
    }

    public int GetHashCode(Person person)
    {
        return $"{person.Name} {person.Age}".GetHashCode();
    }
}