using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double PercentDevider = 100;

    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;

    private Mode mode;
    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory harvesterFactory)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.factory = harvesterFactory;
        this.mode = Mode.Full;
    }
    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(OutputMessage.SuccessfullRegistration,
            harvester.GetType().Name);
    }

    public string Produce()
    {
        double energyRequired = this.harvesters.Sum(h => h.EnergyRequirement * ((int)this.mode / PercentDevider));
        double oreProduced = 0;

        if (this.energyRepository.TakeEnergy(energyRequired))
        {
            oreProduced = this.harvesters.Sum(h => h.Produce() * ((int)this.mode / PercentDevider));

        }

        this.OreProduced += oreProduced;

        return string.Format(OutputMessage.OreOutputToday, oreProduced);
    }

    public string ChangeMode(string newMode)
    {
        var reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        this.mode = Enum.Parse<Mode>(newMode);

        return string.Format(OutputMessage.ModeChangeMessage, this.mode);
    }
}
