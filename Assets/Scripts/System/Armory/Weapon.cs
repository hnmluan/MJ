public class Weapon
{
    public WeaponDataSO dataSO;

    public int level;

    public Weapon(WeaponData data)
    {
        this.dataSO = WeaponDataSO.FindByName(data.weaponCode);
        this.level = data.level;
    }

    public Weapon(WeaponDataSO weaponProfile, int level)
    {
        this.dataSO = weaponProfile;
        this.level = level;
    }
}
