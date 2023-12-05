public class BtnInvBuy : BaseButton
{
    protected override void OnClick() => Inventory.Instance.SellItem(UIInventory.Instance.CurrentItem);
}
