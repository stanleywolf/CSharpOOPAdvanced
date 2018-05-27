public class PressureProvider : Provider
{
    private const int DurabilityLoss = 300;
    private const int EnergyRequirementMultiplier = 2;
    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= DurabilityLoss;
        this.EnergyOutput *= EnergyRequirementMultiplier;
    }
}
