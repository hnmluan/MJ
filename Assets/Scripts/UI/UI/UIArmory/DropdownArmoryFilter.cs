using Assets.SimpleLocalization;
using System;
using UnityEngine;
using static UnityEngine.UI.Dropdown;

[RequireComponent(typeof(LocalizedDropdown))]
public class DropdownArmoryFilter : BaseDropdown
{
    [Header("Filter Weapon Dropdown")]
    [SerializeField] protected LocalizedDropdown localizedDropdown;

    protected virtual void LoadValue()
    {
        dropdown.options.Clear();
        int numberOfValues = Enum.GetValues(typeof(WeaponType)).Length;
        for (int i = 0; i < numberOfValues; i++) dropdown.options.Add(new OptionData());
        WeaponType[] weaponTypes = (WeaponType[])Enum.GetValues(typeof(WeaponType));
        localizedDropdown.LocalizationKeys = Array.ConvertAll(weaponTypes, type => "Weapon.Type." + type.ToString());
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLocalizedDropdown();
        this.LoadValue();
    }

    private void LoadLocalizedDropdown()
    {
        if (this.localizedDropdown != null) return;
        this.localizedDropdown = GetComponent<LocalizedDropdown>();
        Debug.LogWarning(transform.name + ": LoadDropdown", gameObject);
    }

    protected override void OnChanged(int option)
    {
        WeaponType weaponType = (WeaponType)Enum.ToObject(typeof(WeaponType), option);
        UIArmory.Instance.SetArmoryFilter(weaponType);
    }
}
