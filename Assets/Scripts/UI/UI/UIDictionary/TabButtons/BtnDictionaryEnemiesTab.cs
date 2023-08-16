public class BtnDictionaryEnemiesTab : BaseButton
{
    protected override void OnClick()
    {
        UIDictionary.Instance.SetDictionaryFilter(EDictionaryType.Enemies);
        UIDictionaryDetail.Instance.ShowEmptyObj();
    }
}
