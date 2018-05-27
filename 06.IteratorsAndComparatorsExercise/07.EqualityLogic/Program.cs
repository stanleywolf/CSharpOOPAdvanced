using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());

        var sorterSet = new SortedSet<Person>();
        var hashSet = new HashSet<Person>(new PersonEqComparer());
        for (int i = 0; i < number; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

           var person = new Person(name, age);

            sorterSet.Add(person);
            hashSet.Add(person);
        }

        Console.WriteLine(sorterSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}
