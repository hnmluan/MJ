using System;

public class BtnShopReset : BaseButton
{
    protected override void OnClick()
    {
        if (Wallet.Instance.DeductGoldenBalance(10))
        {
            UIShop.Instance.ResetItems();
            UIShop.Instance.UpdateLastTimeRestItem(DateTime.Now);
        }
    }
}
