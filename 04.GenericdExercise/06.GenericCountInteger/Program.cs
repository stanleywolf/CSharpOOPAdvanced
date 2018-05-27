using System;

class Program
{
    static void Main(string[] args)
    {
        var nums = int.Parse(Console.ReadLine());

        Box<double> list = new Box<double>();

        for (int i = 0; i < nums; i++)
        {
            var part = double.Parse(Console.ReadLine());
            list.Add(part);
        }
        var element = double.Parse(Console.ReadLine());

        Console.WriteLine(list.Compare(element));
    }
}