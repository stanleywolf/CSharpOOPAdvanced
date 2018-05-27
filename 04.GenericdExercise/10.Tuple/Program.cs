using System;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        var fullName = input[0] + " " + input[1];
        var adress = input[2];
        var NameAdress = new Tupple<string,string>(fullName,adress);

        var inputTwo = Console.ReadLine().Split();
        var name = inputTwo[0];
        var beersLiter = int.Parse(inputTwo[1]);
        var drunk = new Tupple<string,int>(name, beersLiter);

        var inputThree = Console.ReadLine().Split();
        var integ = int.Parse(inputThree[0]);
        var doub = double.Parse(inputThree[1]);
        var nobody = new Tupple<int,double>(integ, doub);

        Console.WriteLine(NameAdress + Environment.NewLine + drunk + Environment.NewLine + nobody);

    }
}