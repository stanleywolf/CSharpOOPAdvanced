using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
        var stones = new Lake<int>(input);

        Console.WriteLine(string.Join(", ",stones));
    }

}