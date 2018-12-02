﻿using System.Collections.Generic;

public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    int BaseMinDamage { get; }

    int BaseMaxDamage { get; }


    void AddGem(int index, IGem gem);

    void RemoveGem(int index);

    IReadOnlyCollection<IGem> Slots { get; }
}

