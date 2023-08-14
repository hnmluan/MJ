public class BtnInvUseAllItem : BaseButton
{
    protected override void OnClick() => UIInventoryDetail.Instance.ClickUseAllItem();
}
