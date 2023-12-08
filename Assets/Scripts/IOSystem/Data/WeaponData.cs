using System;

[Serializable]

public class WeaponData
{
    public string weaponCode;
    public int level;

    public WeaponData(Weapon weapon)
    {
        this.weaponCode = weapon.dataSO.damageObjectCode.ToString();
        this.level = weapon.level;
    }
}
