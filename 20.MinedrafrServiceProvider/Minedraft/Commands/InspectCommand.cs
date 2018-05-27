using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        int id = int.Parse(this.Arguments[0]);

        var provider = this.providerController.Entities.SingleOrDefault(e => e.ID == id); 

        if (provider != null)
        {
            return provider.ToString();
        }

        var harvester = this.harvesterController.Entities.SingleOrDefault(e => e.ID == id);

        if (harvester != null)
        {
            return harvester.ToString();
        }

        return string.Format(OutputMessage.NoEntityFound, this.Arguments[0]);
    }
}
