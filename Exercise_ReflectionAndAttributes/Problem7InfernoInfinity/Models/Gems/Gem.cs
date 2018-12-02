public abstract class Gem : IGem, IQualitativeGem
{
    protected Gem(GemClarity gemClarity, int strenght, int agility, int vitality)
    {
        this.GemClarity = gemClarity;
        this.Strenght = strenght + (int)GemClarity;
        this.Agility = agility + (int)GemClarity;
        this.Vitality = vitality + (int)GemClarity;
    }

    public int Strenght { get; private set; }
    public int Agility { get; private set; }
    public int Vitality { get; private set; }
    public GemClarity GemClarity { get; private set; }
}

