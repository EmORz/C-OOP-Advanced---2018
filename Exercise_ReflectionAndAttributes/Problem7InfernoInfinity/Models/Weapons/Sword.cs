using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Models.Enum;

namespace Problem7InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(WeaponRarity rarity, string name)
            : base(rarity, name, 4, 6, 3)
        {
        }
    }
}
