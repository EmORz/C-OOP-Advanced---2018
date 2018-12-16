using System;

public abstract class Harvester:IHarvester
{
    private const int InitialDurability = 1000;
    private double durability;
    //private double oreOutput;
    //private double energyRequirement;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Broken entity");
            }

            this.durability = value;
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public void Broke()
    {
        this.Durability -= 100;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }
}