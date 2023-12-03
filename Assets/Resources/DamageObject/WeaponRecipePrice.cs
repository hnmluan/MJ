using System;

[Serializable]
public class WeaponRecipePrice
{
    public CurrencyDataSO data;

    public int quantity;

    public bool isAvailable()
    {
        if (data.currencyCode == CurrencyCode.Silver)
        {
            if (Wallet.Instance.SilverBalance >= quantity) return true;
            else return false;
        }
        if (data.currencyCode == CurrencyCode.Gold)
        {
            if (Wallet.Instance.GoldenBalance >= quantity) return true;
            else return false;
        }
        return false;
    }
}