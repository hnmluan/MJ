
using System;

[Serializable]
public class WeaponData
{
    public string itemCode;
    public int level;
    public int position = 0;
    public bool isFocus = false;

    public WeaponData(ItemArmory item)
    {
        this.itemCode = item.weaponProfile.damageObjectCode.ToString();
        this.level = item.level;
        this.position = item.position;
        this.isFocus = false;
    }
}
