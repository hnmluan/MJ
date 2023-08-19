using UnityEngine;

public class BtnInvBuy : BaseButton
{
    protected override void OnClick()
    {
        string price = UIInvDetail.Instance.BuyItem();

        string resPath = "Currency/SilverProfile";

        CurrencyProfileSO currencySO = Resources.Load<CurrencyProfileSO>(resPath);

        Sprite image = currencySO.currencySprite;

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(price, image);
    }


}
