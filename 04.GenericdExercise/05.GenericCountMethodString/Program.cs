using System;

class Program
{
    static void Main(string[] args)
    {
        var nums = int.Parse(Console.ReadLine());

        Box<string> list = new Box<string>();

        for (int i = 0; i < nums; i++)
        {
            var part = Console.ReadLine();
            list.Add(part);
        }
        var element = Console.ReadLine();
        
        Console.WriteLine(list.Compare(element));
    }
}