﻿using System;

class Program
{
    static void Main(string[] args)
    {
        var spy = new Spy();
        var result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}