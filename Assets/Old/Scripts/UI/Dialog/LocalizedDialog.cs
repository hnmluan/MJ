using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizedDialog : LocalizedText
{
    private static LocalizedDialog instance;
    public static LocalizedDialog Instance { get => instance; }

    protected void Awake()
    {
        if (LocalizedDialog.instance != null) Debug.LogError("Only 1 LocalizedDialog allow to exist");

        LocalizedDialog.instance = this;
    }

    public override void Start()
    {
        LocalizationManager.LocalizationChanged += Localize;
    }

    public string GetDialogLocalizedText(string localizationKey)
    {
        LocalizationKey = localizationKey;
        return LocalizationManager.Localize(localizationKey);
    }
}
