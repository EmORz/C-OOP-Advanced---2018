
using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;



    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var mode = this.Arguments[0];

        var result = this.harvesterController.ChangeMode(mode);
        return result;
    }
}
