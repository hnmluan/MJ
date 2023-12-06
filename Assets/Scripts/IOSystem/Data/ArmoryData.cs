using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ArmoryData
{
    public List<WeaponData> weapons;
    public string equippedWeapon1;
    public string equippedWeapon2;
    public string equippedWeapon3;

    public ArmoryData(Armory armory)
    {
        this.weapons = armory.Weapons.Select(item => new WeaponData(item)).ToList();
        this.equippedWeapon1 = armory.EquippedWeapon1 == null ? null : armory.EquippedWeapon1.id;
        this.equippedWeapon2 = armory.EquippedWeapon2 == null ? null : armory.EquippedWeapon2.id;
        this.equippedWeapon3 = armory.EquippedWeapon3 == null ? null : armory.EquippedWeapon3.id;
    }
}
