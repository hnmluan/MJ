public class BtnInventoryOpen : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.Toggle();
}
