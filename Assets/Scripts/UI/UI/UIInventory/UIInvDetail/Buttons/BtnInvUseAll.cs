public class BtnInvUseAll : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.UIInvDetail.UseAllItem();
}
