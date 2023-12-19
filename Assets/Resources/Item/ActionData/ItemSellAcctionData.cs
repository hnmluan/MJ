using Assets.SimpleLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class ItemSellAcctionData : ItemActionData
{
    public int price;

    public void Sell(int quantity)
    {
        List<string> listPrice = new List<string>();

        for (int i = 0; i < quantity; i++)
        {
            Wallet.Instance.AddSilver(this.price);
            string price = LocalizationManager.Localize("Currency.Silver") + " + " + this.price;
            listPrice.Add(price);
        }

        Sprite image = CurrencyDataSO.FindByCode(CurrencyCode.Silver).currencySprite;

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(listPrice, image);
    }

}
