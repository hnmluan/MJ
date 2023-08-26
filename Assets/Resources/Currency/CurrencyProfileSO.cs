using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyProfileSO", menuName = "SO/CurrencyProfile")]

public class CurrencyProfileSO : ScriptableObject
{
    public CurrencyCode currencyCode = CurrencyCode.NoCurrency;

    public string keyName = "no-name";

    public Sprite currencySprite;

    public string discription;

    public static CurrencyProfileSO FindByItemCode(CurrencyCode currencyCode)
    {
        var profiles = Resources.LoadAll("Currency/ScriptableObject", typeof(CurrencyProfileSO));
        foreach (CurrencyProfileSO profile in profiles)
        {
            if (profile.currencyCode != currencyCode) continue;
            return profile;
        }
        return null;
    }

    public static CurrencyCode GetRandomItemCodeExcludingNoItem()
    {
        CurrencyCode[] currencyCode = (CurrencyCode[])Enum.GetValues(typeof(CurrencyCode));
        CurrencyCode randomCurrencyCode;

        System.Random random = new System.Random();

        do
        {
            randomCurrencyCode = currencyCode[random.Next(currencyCode.Length)];
        } while (randomCurrencyCode == CurrencyCode.NoCurrency);

        return randomCurrencyCode;
    }
}
