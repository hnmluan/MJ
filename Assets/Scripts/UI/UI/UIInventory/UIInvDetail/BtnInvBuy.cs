using UnityEngine;

public class BtnInvBuy : BaseButton
{
    protected override void OnClick()
    {
        CurrencyProfileSO currencySO = CurrencyProfileSO.FindByItemCode(CurrencyCode.Silver);

        Sprite image = currencySO.currencySprite;

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(UIInvDetail.Instance.BuyItem(), image);
    }
}
