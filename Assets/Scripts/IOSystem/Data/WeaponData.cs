
using System;

[Serializable]
public class WeaponData
{
    public string name;
    public int level;

    public WeaponData(string name, int level)
    {
        this.name = name;
        this.level = level;
    }
}
