public class AddCommand : Command
{
    private IGemFactory gemFactory;
    private IRepository repository;

    public AddCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string name = this.Data[0];
        int index = int.Parse(this.Data[1]);

        var tokens = this.Data[2].Split();

        string clarity = tokens[0];
        string type = tokens[1];

        IGem gem = this.gemFactory.GreateGem(clarity, type);
        this.repository.AddGem(name, index, gem);
    }
}

