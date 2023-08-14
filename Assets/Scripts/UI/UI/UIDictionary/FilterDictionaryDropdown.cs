using Assets.SimpleLocalization;
using System;
using UnityEngine;
using static UnityEngine.UI.Dropdown;

[RequireComponent(typeof(LocalizedDropdown))]
public class FilterDictionaryDropdown : BaseDropdown
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
        int numberOfValues = Enum.GetValues(typeof(DictionaryFilter)).Length;
        for (int i = 0; i < numberOfValues; i++) dropdown.options.Add(new OptionData());
        DictionaryFilter[] itemTypes = (DictionaryFilter[])Enum.GetValues(typeof(DictionaryFilter));
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
        DictionaryFilter itemType = (DictionaryFilter)Enum.ToObject(typeof(DictionaryFilter), option);
        UIDictionary.Instance.SetDictionaryFilter(itemType);
    }
}
