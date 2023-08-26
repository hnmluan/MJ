public class BtnInvBuy : BaseButton
{
    protected override void OnClick() => UIInvDetail.Instance.SellItem();
}
