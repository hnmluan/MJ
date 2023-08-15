public class BtnInvUse : BaseButton
{
    protected override void OnClick() => UIInvDetail.Instance.UseItem();
}
