using System;
using UnityEngine;

public enum WeaponCode
{
    NoWeapon,
    Lance,
    Bow
}

public class WeaponCodeParser
{
    public static WeaponCode FromString(string weaponCode)
    {
        try
        {
            return (WeaponCode)System.Enum.Parse(typeof(WeaponCode), weaponCode);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return WeaponCode.NoWeapon;
        }
    }
}
