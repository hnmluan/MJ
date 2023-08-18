using System;

[Serializable]
public class Weapon

{
    public WeaponProfileSO weaponProfile;

    public int level;

    public bool CanUpgrade()
    {
        if (level > weaponProfile.levels.Count) return false;
        return weaponProfile.levels[level].weaponRecipe.CanUpgrade();
    }
}
