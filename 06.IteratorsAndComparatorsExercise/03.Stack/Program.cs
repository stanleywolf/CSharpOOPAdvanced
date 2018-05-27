using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input;
        var stack = new Stack<int>();
        while ((input = Console.ReadLine()) != "END")
        {
            var commandArgs = input.Split(new string[]{" ", ","},StringSplitOptions.RemoveEmptyEntries);
            var command = commandArgs[0];
            
            switch (command)
            {
                case "Push":
                    var elements = commandArgs.Skip(1).Select(int.Parse).ToList();
                    foreach (var element in elements)
                    {
                        stack.Push(element);
                    }
                    break;
                case "Pop":
                    stack.Pop();
                    break;
            }
        }
        for (int i = 0; i < 2; i++)
        {
            stack.PrintElement();
        }
    }
}