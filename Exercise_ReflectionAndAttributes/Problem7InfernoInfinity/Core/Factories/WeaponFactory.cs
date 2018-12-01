﻿using Problem7InfernoInfinity.Contracts;
using Problem7InfernoInfinity.Models.Enum;
using System;

namespace Problem7InfernoInfinity.Core.Factories
{
    public class WeaponFactory: IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponRarity, string weaponType, string name)
        {
            var rarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponRarity);

            Type classType = Type.GetType(weaponType);

            var instance = (IWeapon)Activator.CreateInstance(classType, new object[] { rarity, name });
            return instance;
        }
    }
}
