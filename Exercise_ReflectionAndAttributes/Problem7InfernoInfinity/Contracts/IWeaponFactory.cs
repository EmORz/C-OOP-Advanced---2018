﻿namespace Problem7InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponRarity, string weaponType, string name);
    }
}
