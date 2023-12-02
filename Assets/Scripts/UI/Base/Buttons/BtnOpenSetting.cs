public class BtnOpenSetting : BaseButton
{
    protected override void OnClick() => UISetting.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenSetting()) OnClick();
    }
}
