public class BtnOpenGuide : BaseButton
{
    protected override void OnClick() => UIGuide.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenGuide()) OnClick();
    }
}
