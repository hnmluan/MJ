public class BtnDictionaryNPCsTab : BaseButton
{
    protected override void OnClick()
    {
        UIDictionary.Instance.SetDictionaryFilter(EDictionaryType.NPCs);
        UIDictionaryDetail.Instance.ShowEmptyObj();
    }
}
