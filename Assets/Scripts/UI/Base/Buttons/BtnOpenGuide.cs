public class BtnOpenGuide : BaseButton
{
    protected override void OnClick() => UIGuide.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenGuide()) OnClick();
    }
}
