public class BtnOpenArmory : BaseButton
{
    protected override void OnClick() => UIArmory.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenArmory()) OnClick();
    }
}