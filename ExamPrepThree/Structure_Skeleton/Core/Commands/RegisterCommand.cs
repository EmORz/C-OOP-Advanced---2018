
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var entityType = this.Arguments[0];

        var result = "";

        if (entityType == nameof(Harvester))
        {
            result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        if (entityType == nameof(Provider))
        {
            result = this.providerController.Register(this.Arguments.Skip(1).ToList());

        }

        return result;


    }
}
