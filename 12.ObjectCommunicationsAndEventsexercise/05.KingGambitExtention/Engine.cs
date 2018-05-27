using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private IKing king;

    public Engine(IKing king)
    {
        this.king = king;
    }

    public void Run()
    {
        string input;
        while ((input=Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string command = tokens[0];

            if (command == "Attack")
            {
                king.GetAttacket();
            }
            else if (command == "Kill")
            {
                string name = tokens[1];
                ISubordinate subordinate = king.Subordinates.First(n => n.Name == name);
                
                subordinate.TakeDamage();
            }
        }
    }
}