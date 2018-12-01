using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Models.Enum;

namespace Problem7InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(WeaponRarity rarity, string name)
            : base(rarity, name, 5, 10, 4)
        {
        }
    }
}
