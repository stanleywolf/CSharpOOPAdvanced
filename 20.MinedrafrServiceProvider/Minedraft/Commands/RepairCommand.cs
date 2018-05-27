using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;
    public RepairCommand(IList<string> arguments, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        double repairValue = double.Parse(this.Arguments[0]);

       return this.providerController.Repair(repairValue);
    }
}
