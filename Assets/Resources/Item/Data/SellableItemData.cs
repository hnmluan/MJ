using Assets.SimpleLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class SellableItemData : ItemData
{
    public int price;

    public void SellItem(int quantity)
    {
        List<string> listPrice = new List<string>();

        for (int i = 0; i < quantity; i++)
        {
            Wallet.Instance.AddSilverBalance(this.price);
            string price = LocalizationManager.Localize("Currency.Silver") + " +" + this.price;
            listPrice.Add(price);
        }

        Sprite image = CurrencyProfileSO.FindByItemCode(CurrencyCode.Silver).currencySprite;

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(listPrice, image);
    }

}
