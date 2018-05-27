using System;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        var fullName = input[0] + " " + input[1];
        var adress = input[2];
        var town = input[3];
        var NameAdress = new Threeuple<string, string, string>(fullName, adress, town);

        var inputTwo = Console.ReadLine().Split();
        var name = inputTwo[0];
        var beersLiter = int.Parse(inputTwo[1]);
        var drunkOrNot = inputTwo[2] == "drunk";
        var drunk = new Threeuple<string, int,bool>(name, beersLiter, drunkOrNot);

        var inputThree = Console.ReadLine().Split();
        var nameThree = inputThree[0];
        var accauntBalance = double.Parse(inputThree[1]);
        var bankName = inputThree[2];
        var manager = new Threeuple<string, double,string>(nameThree, accauntBalance,bankName);

        Console.WriteLine(NameAdress + Environment.NewLine + drunk + Environment.NewLine + manager);
    }
}