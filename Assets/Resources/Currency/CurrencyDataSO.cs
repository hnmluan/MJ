using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "ScriptableObject/Currency")]

public class CurrencyDataSO : ScriptableObject
{
    public CurrencyCode currencyCode = CurrencyCode.NoCurrency;

    public string keyName = "no-name";

    public Sprite currencySprite;

    public string discription;

    public static CurrencyDataSO FindByItemCode(CurrencyCode currencyCode)
    {
        var profiles = Resources.LoadAll("Currency/ScriptableObject", typeof(CurrencyDataSO));
        foreach (CurrencyDataSO profile in profiles)
        {
            if (profile.currencyCode != currencyCode) continue;
            return profile;
        }
        return null;
    }

    public static CurrencyDataSO FindByName(string name)
    {
        CurrencyCode currencyCode;
        Enum.TryParse(name, out currencyCode);
        return FindByItemCode(currencyCode);
    }
}
