using System.Collections.Generic;
using System.Linq;

public abstract class Weapon : IWeapon, IRareWeapon
{
    IGem[] slots;

    protected Weapon(WeaponRarity rarity, string name, int baseMinDamage, int baseMaxDamage, int slots)
    {
        this.Rarity = rarity;
        this.Name = name;
        this.BaseMinDamage = baseMinDamage;
        this.BaseMaxDamage = baseMaxDamage;
        this.slots = new IGem[slots];
    }

    public WeaponRarity Rarity { get; private set; }
    public string Name { get; private set; }
    public int BaseMinDamage { get; private set; }
    public int BaseMaxDamage { get; private set; }

    public int MinDamage
    {
        get
        {
            return this.BaseMinDamage * (int)Rarity + this.Slots
                       .Where(g => g != null)
                       .Sum(g => g.Strenght * 2 + g.Agility);
        }
    }
    public int MaxDamage
    {
        get
        {
            return this.BaseMaxDamage * (int)Rarity + this.Slots
                       .Where(g => g != null)
                       .Sum(g => g.Strenght * 3 + g.Agility * 4);
        }
    }


    public void AddGem(int index, IGem gem)
    {
        var temp = IsInBorder(index);
        if (temp)
        {
            this.slots[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        var temp = IsInBorder(index);
        if (temp)
        {
            this.slots[index] = null;
        }
    }

    public IReadOnlyCollection<IGem> Slots => this.slots;

    private bool IsInBorder(int index)
    {
        if (index >= 0 && index < this.Slots.Count)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        int strength = this.Slots
            .Where(g => g != null)
            .Sum(g => g.Strenght);

        int agility = this.Slots
            .Where(g => g != null)
            .Sum(g => g.Agility);

        int vitality = this.Slots
            .Where(g => g != null)
            .Sum(g => g.Vitality);

        return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}

