using System;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int DurabilityLoss = 100;

    private double durability;
    public int ID { get; protected set; }

    public double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            this.durability = value;
        }
    }

    public double EnergyOutput { get; protected set; }

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityLoss;

        if (this.Durability < 0)
        {
            throw new ArgumentException();
        }
    }
    public void Repair(double val)
    {
        this.Durability += val;
    }
    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}Durability: {this.durability}";
    }
}