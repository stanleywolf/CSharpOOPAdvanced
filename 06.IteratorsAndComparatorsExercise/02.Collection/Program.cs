using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string input;
        var listy = new ListyIterator<string>();

        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                var commandArgs = input.Split();
                var command = commandArgs[0];
                var element = commandArgs.Skip(1).ToList();

                switch (command)
                {
                    case "Create":
                        listy.Create(element);
                        break;
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        listy.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "PrintAll":
                        listy.PrintAll();
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
