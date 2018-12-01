using Problem7InfernoInfinity.Models.Enum;

namespace Problem7InfernoInfinity.Models.Weapons
{
    public class Knife : Weapon
    {
        public Knife(WeaponRarity rarity, string name)
            : base(rarity, name, 3, 4, 2)
        {
        }
    }
}
