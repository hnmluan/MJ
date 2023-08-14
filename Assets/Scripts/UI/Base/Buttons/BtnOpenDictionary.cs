public class BtnOpenDictionary : BaseButton
{
    protected override void OnClick() => UIDictionary.Instance.Toggle();
}