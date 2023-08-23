public class BtnOpenArmory : BaseButton
{
    protected override void OnClick() => UIArmory.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenArmory()) OnClick();
    }
}