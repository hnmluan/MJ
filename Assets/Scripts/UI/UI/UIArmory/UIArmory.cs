using System.Collections.Generic;
using UnityEngine;

public class UIArmory : BaseUI
{
    [Header("UI Armory")]
    private static UIArmory instance;
    public static UIArmory Instance => instance;

    [SerializeField] protected ArmorySort armorySort = ArmorySort.ByName;

    [SerializeField] protected WeaponType armoryFilter = WeaponType.NoType;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmory.instance != null) Debug.LogError("Only 1 UIArmory allow to exist");
        UIArmory.instance = this;
    }

    public void SetArmorySort(ArmorySort armorySort)
    {
        this.armorySort = armorySort;
        this.ShowWeapons();
    }

    public void SetArmoryFilter(WeaponType armoryFilter)
    {
        this.armoryFilter = armoryFilter;
        this.ShowWeapons();
    }

    public override void Open()
    {
        base.Open();
        ShowWeapons();
    }

    private void ShowWeapons()
    {
        this.ClearWeapons();
        List<Weapon> weapons = Armory.Instance.Weapons;
        foreach (Weapon weapon in weapons) UIArmoryItemSpawner.Instance.SpawnWeapon(weapon);
    }

    protected virtual void ClearWeapons() => UIArmoryItemSpawner.Instance.ClearWeapons();
}
