using System.Collections.Generic;
using UnityEngine;

public class Armory : InitMonoBehaviour
{
    private static Armory instance;
    public static Armory Instance { get => instance; }

    [SerializeField] protected List<Weapon> weapons;
    public List<Weapon> Weapons => weapons;

    protected override void Awake()
    {
        base.Awake();
        if (Armory.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        Armory.instance = this;
    }

    protected override void Start()
    {
        AddItem(WeaponCode.Lance, 3);
        AddItem(WeaponCode.Bow, 3);
    }

    public virtual void AddItem(WeaponCode weaponCode, int addCount)
    {
        for (int i = 0; i < addCount; i++)
        {
            Weapon weapon = new Weapon();
            weapon.weaponProfile = GetWeaponProfile(weaponCode);
            weapon.level = 1;
            weapons.Add(weapon);
        }
    }

    public virtual void DecomposeWeapons(Weapon weapon)
    {

    }

    protected virtual WeaponProfileSO GetWeaponProfile(WeaponCode weaponCode)
    {
        var profiles = Resources.LoadAll("DamageObject", typeof(WeaponProfileSO));
        foreach (WeaponProfileSO profile in profiles)
        {
            if (profile.damageObjectCode != weaponCode) continue;
            return profile;
        }
        return null;
    }
}
