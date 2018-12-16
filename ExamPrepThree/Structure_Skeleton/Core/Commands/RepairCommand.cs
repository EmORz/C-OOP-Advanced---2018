
using System.Collections.Generic;

public class RepairCommand : Command
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController) : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var val = double.Parse(this.Arguments[0]);

        var resut = this.providerController.Repair(val);
        return resut;
    }
}
