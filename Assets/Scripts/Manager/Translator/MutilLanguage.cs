using Assets.SimpleLocalization;
using UnityEngine;

public class MutilLanguage : InitMonoBehaviour
{
    private static MutilLanguage instance;
    public static MutilLanguage Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MutilLanguage.instance != null) Debug.Log("Only 1 MutilLanguage allow to exist");
        MutilLanguage.instance = this;

        LocalizationManager.Read();

        switch (Application.systemLanguage)
        {
            case SystemLanguage.Vietnamese:
                LocalizationManager.Language = "Vietnamese";
                break;
            default:
                LocalizationManager.Language = "English";
                break;
        }
    }

    public void LanguageSwitcher(int index)
    {
        switch (index)
        {
            case 0:
                LocalizationManager.Language = "English";
                break;
            case 1:
                LocalizationManager.Language = "Vietnamese";
                break;
            default:
                LocalizationManager.Language = "English";
                break;
        }
    }
}
