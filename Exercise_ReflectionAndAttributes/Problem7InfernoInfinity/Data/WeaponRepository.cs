using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Contracts;

namespace Problem7InfernoInfinity.Data
{
    public class WeaponRepository : IRepository
    {
        private Dictionary<string, IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, IWeapon>();
        }
        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon.Name, weapon);
        }

        public void AddGem(string weaponName, int index, IGem gem)
        {
            var weapon = this.weapons[weaponName];
            weapon.AddGem(index, gem);
        }

        public void RemoveGem(string weaponName, int index)
        {
            var weapon = this.weapons[weaponName];
            weapon.RemoveGem(index);
        }

        public string PrintWeapon(string name)
        {
            var weapon = this.weapons[name];
            return weapon.ToString();
        }
    }
}
