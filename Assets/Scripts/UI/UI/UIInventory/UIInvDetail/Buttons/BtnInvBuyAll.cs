public class BtnInvBuyAll : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.UIInvDetail.SellAllItem();
}
