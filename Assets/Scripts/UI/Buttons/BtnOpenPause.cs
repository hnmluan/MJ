public class BtnOpenPause : BaseButton
{
    protected override void OnClick() => UIPause.Instance.Toggle();
}
