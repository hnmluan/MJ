
using System;
using System.Collections.Generic;

[Serializable]

public class WeaponRecipe
{
    public List<WeaponRecipeIngredient> recipeIngredients;

    public List<WeaponRecipePrice> recipePrice;

    public bool CanUpgrade()
    {
        bool CanUpgrade = true;
        foreach (WeaponRecipeIngredient item in recipeIngredients)
        {
            if (item.itemCount > Inventory.Instance.GetQuantity(item.itemProfile.itemCode)) CanUpgrade = false;
        }
        foreach (WeaponRecipePrice item in recipePrice)
        {
            if (item.currencyProfile.currencyCode == CurrencyCode.Gold)
                if (item.currencyCout > Wallet.Instance.GoldenBalance) CanUpgrade = false;
            if (item.currencyProfile.currencyCode == CurrencyCode.Silver)
                if (item.currencyCout > Wallet.Instance.SilverBalance) CanUpgrade = false;
        }
        return CanUpgrade;
    }
}
