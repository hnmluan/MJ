public class BtnCloseDictionary : BaseButton
{
    protected override void OnClick() => UIDictionary.Instance.Close();
}