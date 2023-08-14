using Assets.SimpleLocalization;
using System;
using UnityEngine;
using static UnityEngine.UI.Dropdown;

[RequireComponent(typeof(LocalizedDropdown))]
public class FilterDropdown : BaseDropdown
{
    [Header("Filter Item Dropdown")]
    [SerializeField] protected LocalizedDropdown localizedDropdown;

    protected virtual void LoadValue()
    {
        dropdown.options.Clear();
        int numberOfValues = Enum.GetValues(typeof(ItemType)).Length;
        for (int i = 0; i < numberOfValues; i++) dropdown.options.Add(new OptionData());
        ItemType[] itemTypes = (ItemType[])Enum.GetValues(typeof(ItemType));
        localizedDropdown.LocalizationKeys = Array.ConvertAll(itemTypes, type => "Item.Type." + type.ToString());
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
        ItemType itemType = (ItemType)Enum.ToObject(typeof(ItemType), option);
        UIDictionary.Instance.SetDictionaryFilter(itemType);
    }
}
