public class BtnOpenInventory : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.Toggle();
}
