public class BtnOpenSetting : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.Toggle();
}
