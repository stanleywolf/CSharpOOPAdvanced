using System;

class Program
{
    static void Main(string[] args)
    {
        var nums = int.Parse(Console.ReadLine());

        for (int i = 0; i < nums; i++)
        {
            var box = new Box<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(box);
        }
    }
}