
using System;

[Serializable]
public class ItemArmoryData
{
    public WeaponData weapon;
    public int position = 0;
    public bool isFocus = false;

    public ItemArmoryData(ItemArmory item)
    {
        this.weapon = new WeaponData(item.weapon);
        this.position = item.position;
        this.isFocus = item.isFocus;
    }
}
