﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person:IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Town { get; private set; }

    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town; 
    }

    public int CompareTo(Person other)
    {
        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
            if (result == 0)
            {
                result = this.Town.CompareTo(other.Town);
            }
        }
        return result;
    }
}