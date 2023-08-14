using Assets.SimpleLocalization;
using System;
using UnityEngine;
using static UnityEngine.UI.Dropdown;

[RequireComponent(typeof(LocalizedDropdown))]
public class DropdownDictionaryType : BaseDropdown
{
    [Header("Filter Dictionary Dropdown")]
    [SerializeField] protected LocalizedDropdown localizedDropdown;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLocalizedDropdown();
        this.LoadValue();
    }

    protected virtual void LoadValue()
    {
        dropdown.options.Clear();
        int numberOfValues = Enum.GetValues(typeof(EDictionaryType)).Length;
        for (int i = 0; i < numberOfValues; i++) dropdown.options.Add(new OptionData());
        EDictionaryType[] itemTypes = (EDictionaryType[])Enum.GetValues(typeof(EDictionaryType));
        localizedDropdown.LocalizationKeys = Array.ConvertAll(itemTypes, type => "Dictionary.Type." + type.ToString());
    }

    private void LoadLocalizedDropdown()
    {
        if (this.localizedDropdown != null) return;
        this.localizedDropdown = GetComponent<LocalizedDropdown>();
        Debug.LogWarning(transform.name + ": LoadDropdown", gameObject);
    }

    protected override void OnChanged(int option)
    {
        EDictionaryType itemType = (EDictionaryType)Enum.ToObject(typeof(EDictionaryType), option);
        UIDictionary.Instance.SetDictionaryFilter(itemType);
        UIDictionaryDetail.Instance.ShowEmptyObj();
    }
}
