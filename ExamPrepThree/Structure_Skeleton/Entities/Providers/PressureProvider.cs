
public class PressureProvider : Provider
{
    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability -= 300;
        this.EnergyOutput *= 2;
    }
}
