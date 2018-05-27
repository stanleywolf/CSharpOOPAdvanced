using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string typeToRegister = this.Arguments[0];

        if (typeToRegister == nameof(Harvester))
        {
            return this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }

        else if (typeToRegister == nameof(Provider))
        {
            return this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return string.Empty;
    }

}
