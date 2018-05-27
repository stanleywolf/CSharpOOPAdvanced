using System;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int DurabilityLoss = 100;

    private double durability;
    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; protected set; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
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
    public double Produce()
    {
        return this.OreOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityLoss;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}Durability: {this.durability}";
    }
}