public class BtnOpenGuide : BaseButton
{
    protected override void OnClick() => UIGuide.Instance.Toggle();
}
