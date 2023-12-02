public class BtnOpenPause : BaseButton
{
    protected override void OnClick() => UIPause.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenPause()) OnClick();
    }
}
