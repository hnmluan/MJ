public class BtnCloseGuide : BaseButton
{
    protected override void OnClick() => UIGuide.Instance.Close();
}
