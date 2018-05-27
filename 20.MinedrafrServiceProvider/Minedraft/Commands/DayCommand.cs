using System;
using System.Collections.Generic;
public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    public DayCommand(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        return $"{this.providerController.Produce()}{Environment.NewLine}{this.harvesterController.Produce()}";
    }
}
