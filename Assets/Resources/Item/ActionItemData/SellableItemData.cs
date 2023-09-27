using System;

[Serializable]

public class SellableItemData : ActionItemData
{
    public int price;

    protected override void Action()
    {
        /*        List<string> listPrice = new List<string>();

                for (int i = 0; i < quantity; i++)
                {
                    Wallet.Instance.AddSilverBalance(this.price);
                    string price = LocalizationManager.Localize("Currency.Silver") + " +" + this.price;
                    listPrice.Add(price);
                }

                Sprite image = CurrencyDataSO.FindByItemCode(CurrencyCode.Silver).currencySprite;

                UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(listPrice, image);*/

        Wallet.Instance.AddSilverBalance(this.price);
    }

    protected override void SetKeyActionLocalization() => this.KeyActionLocalization = "Drop";
}
