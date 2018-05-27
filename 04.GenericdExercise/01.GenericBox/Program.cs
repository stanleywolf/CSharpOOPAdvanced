using System;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var result = int.TryParse(input, out int res);
        
        if(!result)
        {
           var box = new Box<string>(input);
            Console.WriteLine(box);
        }
        else
        {
           var box = new Box<int>(res);
            Console.WriteLine(box);
        }
        
    }
}