public class BtnInvUse : BaseButton
{
    protected override void OnClick() => UIInventory.Instance.UIInvDetail.UseItem();
}
