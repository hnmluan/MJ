using System.Collections.Generic;
using UnityEngine;

public class Armory : Singleton<Armory>
{
    [SerializeField] protected List<Weapon> weapons;
    public List<Weapon> Weapons => weapons;

    [SerializeField] public float ratioDecompose;

    protected override void Start()
    {
        AddItem(WeaponCode.Bow, 3, 3);
        AddItem(WeaponCode.Lance, 3, 1);
        AddItem(WeaponCode.Lance, 3, 2);
        AddItem(WeaponCode.Bow, 3, 3);
        AddItem(WeaponCode.Bow, 3, 1);
    }

    public virtual void AddItem(WeaponCode weaponCode, int addCount, int level)
    {
        for (int i = 0; i < addCount; i++)
        {
            Weapon weapon = new Weapon();
            weapon.weaponProfile = GetWeaponProfile(weaponCode);
            weapon.level = level;
            weapons.Add(weapon);
        }
    }

    protected virtual WeaponDataSO GetWeaponProfile(WeaponCode weaponCode)
    {
        var profiles = Resources.LoadAll("DamageObject/ScriptableObject/", typeof(WeaponDataSO));
        foreach (WeaponDataSO profile in profiles)
        {
            if (profile.damageObjectCode != weaponCode) continue;
            return profile;
        }
        return null;
    }
}
