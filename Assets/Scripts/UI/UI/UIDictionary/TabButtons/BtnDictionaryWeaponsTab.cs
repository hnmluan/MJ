public class BtnDictionaryWeaponsTab : BaseButton
{
    protected override void OnClick()
    {
        UIDictionary.Instance.SetDictionaryFilter(EDictionaryType.Weapons);
        UIDictionaryDetail.Instance.ShowEmptyObj();
    }
}
