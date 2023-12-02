public class DropdownLanguage : BaseDropdown
{
    protected override void OnChanged(int option) => MutilLanguage.Instance.LanguageSwitcher(option);
}
