public class BtnCloseShop : BaseButton
{
    protected override void OnClick() => UIShop.Instance.Close();
}