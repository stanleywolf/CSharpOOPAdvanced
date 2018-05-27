using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
       string input;
        var persons = new List<Person>();
        while ((input=Console.ReadLine()) != "END")
        {
            var inputArgs = input.Split();
            var name = inputArgs[0];
            var age = int.Parse(inputArgs[1]);
            var town = inputArgs[2];

            var person = new Person(name, age, town);

            persons.Add(person);
        }

        var number = int.Parse(Console.ReadLine());
        Person comparePerson = persons[number - 1];

        persons.RemoveAt(number - 1);

        int equal = 1, notEqual = 0;
        foreach (var person in persons)
        {
            if (comparePerson.CompareTo(person) == 0)
            {
                equal++;
            }
            else
            {
                notEqual++;
            }
        }
        if (equal <= 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equal} {notEqual} {persons.Count + 1}");
        }
        
    }
}