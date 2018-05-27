using System;

class Program
{
    static void Main(string[] args)
    {
        var nums = int.Parse(Console.ReadLine());

        Box<int> list = new Box<int>();

        for (int i = 0; i < nums; i++)
        {
            var part = int.Parse(Console.ReadLine());
            list.Add(part);
        }
        var indexes = Console.ReadLine().Split();
        var first = int.Parse(indexes[0]);
        var second = int.Parse(indexes[1]);

        list.SwapByIndex(first, second);
        for (int i = 0; i < nums; i++)
        {
            Console.WriteLine("System.Int32: " + list[i]);

        }
    }
}
