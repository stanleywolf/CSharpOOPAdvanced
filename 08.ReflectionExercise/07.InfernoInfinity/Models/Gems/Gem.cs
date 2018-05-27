using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gem : IGem
{
    public int Strength { get; }
    public int Agility { get; }
    public int Vitality { get; }

    public GemClarity Clarity { get; private set; }

    protected Gem(GemClarity clarity, int strength, int agility,int vitality)
    {
        this.Clarity = clarity;
        this.Strength = strength + (int) clarity;
        this.Agility = agility + (int) clarity;
        this.Vitality = vitality + (int) clarity;
    }
}