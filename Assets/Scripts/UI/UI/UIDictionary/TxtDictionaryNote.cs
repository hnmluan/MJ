using Assets.SimpleLocalization;
using UnityEngine;

public class TxtDictionaryNote : BaseText
{
    [Header("Txt Dictionary Note")]

    [SerializeField] protected LocalizedText localizedText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLocalizedText();
    }
    private void LoadLocalizedText()
    {
        if (this.localizedText != null) return;
        this.localizedText = transform.GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadLocalizedText", gameObject);
    }

    protected override void Start() => localizedText.LocalizationKey = "empty";

    private void Update()
    {
        if (UIDictionary.Instance.DictionaryType == EDictionaryType.Enemies) localizedText.LocalizationKey = "Dictionary.NoteEnemies";
        if (UIDictionary.Instance.DictionaryType == EDictionaryType.NPCs) localizedText.LocalizationKey = "Dictionary.NoteNpcs";
        if (UIDictionary.Instance.DictionaryType == EDictionaryType.Weapons) localizedText.LocalizationKey = "Dictionary.NoteWeapons";
        localizedText.Localize();
    }
}
