public class BtnShopReset : BaseButton
{
    protected override void OnClick()
    {
        Shop.Instance.ResetItem();
        UIShop.Instance.RefreshUI();
    }
}
