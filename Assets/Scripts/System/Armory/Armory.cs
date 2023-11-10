using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Armory : Singleton<Armory>
{
    [SerializeField] protected List<Weapon> weapons;
    public List<Weapon> Weapons => weapons;

    public Weapon firstWeapon;

    public Weapon secondWeapon;

    [SerializeField] public float ratioDecompose;

    protected override void Awake()
    {
        base.Awake();
        LoadData();
    }

    public void LoadData()
    {
        ArmoryData armoryData = SaveLoadHandler.LoadFromFile<ArmoryData>(FileNameData.Armory);

        if (armoryData == null)
        {
            AddItem(WeaponCode.Bow, 3, 3);
            AddItem(WeaponCode.Lance, 3, 1);
            AddItem(WeaponCode.Lance, 3, 2);
            AddItem(WeaponCode.Bow, 3, 3);
            AddItem(WeaponCode.Bow, 3, 1);
            SaveData();
            return;
        }

        weapons = armoryData.weapons.Select(item => new Weapon(WeaponDataSO.FindByName(item.name), item.level)).ToList();
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Armory, new ArmoryData(this));

    public virtual void AddItem(WeaponCode weaponCode, int addCount, int level)
    {
        for (int i = 0; i < addCount; i++)
        {
            Weapon weapon = new Weapon(WeaponDataSO.FindByItemCode(weaponCode), level);
            weapons.Add(weapon);
        }
        SaveData();
    }

    public virtual void DeductItem(Weapon weapon)
    {
        this.weapons.Remove(weapon);
        SaveData();
    }
}
