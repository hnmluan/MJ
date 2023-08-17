public class BtnOpenArmory : BaseButton
{
    protected override void OnClick() => UIArmory.Instance.Toggle();
}