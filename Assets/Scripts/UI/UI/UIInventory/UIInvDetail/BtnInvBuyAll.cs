using UnityEngine;

public class BtnInvBuyAll : BaseButton
{
    protected override void OnClick()
    {
        string resPath = "Currency/SilverProfile";

        CurrencyProfileSO currencySO = Resources.Load<CurrencyProfileSO>(resPath);

        Sprite image = currencySO.currencySprite;

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(UIInvDetail.Instance.BuyAllItem(), image);
    }
}
