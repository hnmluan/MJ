public class LanguageDropdown : BaseDropdown
{
    protected override void OnChanged(int option) => MutilLanguage.Instance.LanguageSwitcher(option);
}
