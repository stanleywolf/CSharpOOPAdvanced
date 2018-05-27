using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IKing king = SetUpKing();
        Engine engine = new Engine(king);
        engine.Run();
    }

    private static IKing SetUpKing()
    {
        string kingName = Console.ReadLine();   
        IKing king = new King(kingName,new List<ISubordinate>());

        string[] royalGuardNames = Console.ReadLine().Split();
        foreach (var royalGuardName in royalGuardNames)
        {
            king.AddSubordinated(new RoyalGuard(royalGuardName));
        }
        string[] footmanNames = Console.ReadLine().Split();
        foreach (var footmanName in footmanNames)
        {
            king.AddSubordinated(new Footman(footmanName));
        }
        return king;
    }
}