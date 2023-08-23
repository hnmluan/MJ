public class BtnOpenSetting : BaseButton
{
    protected override void OnClick() => UISetting.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenSetting()) OnClick();
    }
}
