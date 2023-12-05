public class BtnInvBuyAll : BaseButton
{
    protected override void OnClick() => Inventory.Instance.SellAllItem(UIInventory.Instance.CurrentItem);
}
