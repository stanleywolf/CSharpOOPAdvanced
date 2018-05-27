using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numOfPerson = int.Parse(Console.ReadLine());
        var peopleByName = new SortedSet<Person>(new PersonComparatorOne());
        var peopleByAge = new SortedSet<Person>(new PersonComparator());
        for (int i = 0; i < numOfPerson; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

            var person = new Person(name, age);

            peopleByName.Add(person);
            peopleByAge.Add(person);
        }
        
        foreach (var person in peopleByName)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
        
        foreach (var person in peopleByAge)
        {
            Console.WriteLine(person.Name + " " + person.Age);
        }
        
    }
}