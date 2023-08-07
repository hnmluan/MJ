public class BtnOpenSetting : BaseButton
{
    protected override void OnClick() => UISetting.Instance.Toggle();
}
