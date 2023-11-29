using Assets.SimpleLocalization;
using UnityEngine;

public class BtnShopReset : BaseButton
{
    protected override void OnClick()
    {
        if (Wallet.Instance.DeductSilverBalance(10))
        {
            string nameCurrency = LocalizationManager.Localize(CurrencyDataSO.FindByItemCode(CurrencyCode.Silver).keyName);
            string content = nameCurrency + " - 10";
            Sprite image = CurrencyDataSO.FindByItemCode(CurrencyCode.Silver).currencySprite;
            UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(content, image);
            Shop.Instance.ResetItem();
            UIShop.Instance.RefreshUI();
            return;
        };

        string balanceNotEnough = LocalizationManager.Localize("Shop.BalanceNotEnough");
        UITextSpawner.Instance.SpawnUITextWithMousePosition(balanceNotEnough);
    }
}
