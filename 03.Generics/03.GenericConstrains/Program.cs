using System;

class Program
{
    static void Main(string[] args)
    {
       var scale = new Scale<string>("Gosho", "Pesho");
        
        Console.WriteLine(scale.GetHeavier());
    }
}