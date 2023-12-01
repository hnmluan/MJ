public class BtnInvBuy : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.UIInvDetail.SellItem();
}
