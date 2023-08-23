public class BtnOpenPause : BaseButton
{
    protected override void OnClick() => UIPause.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenPause()) OnClick();
    }
}
