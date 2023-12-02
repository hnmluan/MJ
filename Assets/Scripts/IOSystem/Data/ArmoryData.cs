using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ArmoryData
{
    public List<WeaponData> weapons;

    public ArmoryData(Armory armory) =>
        this.weapons = armory.Weapons.Select(item => new WeaponData(item.weaponProfile.damageObjectCode.ToString(), item.level)).ToList();
}
