public class BtnInvUseItem : BaseButton
{
    protected override void OnClick() => UIInventoryDetail.Instance.ClickUseItem();
}
