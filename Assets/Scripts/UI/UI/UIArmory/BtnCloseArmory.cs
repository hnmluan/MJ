public class BtnCloseArmory : BaseButton
{
    protected override void OnClick() => UIArmory.Instance.Close();
}