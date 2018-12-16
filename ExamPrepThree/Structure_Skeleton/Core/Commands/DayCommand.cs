
using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var providerResult = this.providerController.Produce();
        var harvestResult = this.harvesterController.Produce();

        return providerResult + Environment.NewLine + harvestResult;
    }
}
