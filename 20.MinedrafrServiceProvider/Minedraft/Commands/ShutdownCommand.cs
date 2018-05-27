using System;
using System.Collections.Generic;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    public ShutdownCommand(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string message = string.Format(OutputMessage.ShutDownMessage, Environment.NewLine, this.providerController.TotalEnergyProduced, Environment.NewLine, this.harvesterController.OreProduced);

        return message;
    }
}
