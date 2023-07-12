using Assets.SimpleLocalization;
using UnityEngine;

public class MutilLanguage : MonoBehaviour
{
    private void Awake()
    {
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
