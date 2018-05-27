public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }
    public bool TakeEnergy(double energyNeeded)
    {
        if (energyNeeded <= this.EnergyStored)
        {
            this.EnergyStored -= energyNeeded;
            return true;
        }

        return false;
    }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }
}
