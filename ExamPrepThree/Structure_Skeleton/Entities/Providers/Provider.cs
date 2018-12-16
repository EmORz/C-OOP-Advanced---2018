using System;

public abstract class Provider : IProvider
{

    private const double DefaultDurability = 1000;
    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DefaultDurability;
    }

    public double EnergyOutput { get; protected set; }


    public int ID { get; protected set; }

    public double Durability
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
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecrese;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine+$"Durability: {this.Durability}";
    }
}