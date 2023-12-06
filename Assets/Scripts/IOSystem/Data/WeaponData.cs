
using System;

[Serializable]
public class WeaponData
{
    public string id;
    public string name;
    public int level;

    public WeaponData(ItemArmory item)
    {
        this.name = item.weaponProfile.damageObjectCode.ToString();
        this.level = item.level;
        this.id = item.id;
    }
}
