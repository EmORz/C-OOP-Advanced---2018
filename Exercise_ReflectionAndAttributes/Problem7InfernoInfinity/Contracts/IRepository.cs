public interface IRepository
{
    void AddWeapon(IWeapon weapon);

    void AddGem(string weaponName, int index, IGem gem);

    void RemoveGem(string weaponName, int index);

    string PrintWeapon(string name);
}

