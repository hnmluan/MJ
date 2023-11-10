using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageObject", menuName = "ScriptableObject/DOSO")]
public class WeaponDataSO : ScriptableObject
{
    public WeaponCode damageObjectCode = WeaponCode.NoWeapon;

    public WeaponType damageObjectType = WeaponType.NoType;

    public string keyName;

    public string keyDescription;

    public Sprite spriteInHand;

    public Sprite spriteInAttack;

    public float range;

    public float speed;

    public float attackTime;

    public float attackRate;

    public List<WeaponLevel> levels;

    public static WeaponDataSO FindByItemCode(WeaponCode weaponCode)
    {
        var profiles = Resources.LoadAll("DamageObject/ScriptableObject", typeof(WeaponDataSO));
        foreach (WeaponDataSO profile in profiles)
        {
            if (profile.damageObjectCode != weaponCode) continue;
            return profile;
        }
        return null;
    }

    public static WeaponDataSO FindByName(string name)
    {
        WeaponCode weaponCode;
        Enum.TryParse(name, out weaponCode);
        return FindByItemCode(weaponCode);
    }
}