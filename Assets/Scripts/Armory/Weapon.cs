using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Weapon
{
    public WeaponProfileSO weaponProfile;

    public int level;

    public bool CanUpgrade()
    {
        if (level >= weaponProfile.levels.Count) return false;
        return weaponProfile.levels[level].weaponRecipe.CanUpgrade();
    }

    public bool Upgrade()
    {
        if (!CanUpgrade()) return false;

        List<WeaponRecipeIngredient> recipeIngredients = weaponProfile.levels[level].weaponRecipe.recipeIngredients;
        List<WeaponRecipePrice> recipePrices = weaponProfile.levels[level].weaponRecipe.recipePrice;

        foreach (WeaponRecipeIngredient item in recipeIngredients)
        {
            Inventory.Instance.DeductItem(item.itemProfile.itemCode, item.itemCount);
        }
        foreach (WeaponRecipePrice item in recipePrices)
        {
            if (item.currencyProfile.currencyCode == CurrencyCode.Gold) Wallet.Instance.DeductGoldenBalance(item.currencyCout);
            if (item.currencyProfile.currencyCode == CurrencyCode.Silver) Wallet.Instance.DeductSilverBalance(item.currencyCout);
        }
        level++;
        return true;
    }

    public void Decompose()
    {
        foreach (WeaponRecipeIngredient recipeDecompose in GetRecipeDecompose())
        {
            Inventory.Instance.AddItem(recipeDecompose.itemProfile.itemCode, recipeDecompose.itemCount);
        }
        Armory.Instance.Weapons.Remove(this);
    }

    public List<WeaponRecipeIngredient> GetRecipeDecompose()
    {
        try
        {
            List<WeaponRecipeIngredient> recipeDecomposes = new List<WeaponRecipeIngredient>();

            for (int i = 0; i < level; i++) recipeDecomposes.AddRange(this.weaponProfile.levels[i].weaponRecipe.recipeIngredients);

            recipeDecomposes = SimplifyRecipe(recipeDecomposes);

            recipeDecomposes = MultiplyItemCount(recipeDecomposes, Armory.Instance.ratioDecompose);

            return recipeDecomposes;
        }
        catch
        {
            return null;
        }

    }

    public static List<WeaponRecipeIngredient> SimplifyRecipe(List<WeaponRecipeIngredient> recipeDecomposes)
    {
        var simplifiedList = new List<WeaponRecipeIngredient>();

        foreach (var ingredient in recipeDecomposes)
        {
            var existingIngredient = simplifiedList.Find(item => item.itemProfile == ingredient.itemProfile);
            if (existingIngredient != null)
            {
                existingIngredient.itemCount += ingredient.itemCount;
            }
            else
            {
                simplifiedList.Add(new WeaponRecipeIngredient
                {
                    itemProfile = ingredient.itemProfile,
                    itemCount = ingredient.itemCount
                });
            }
        }

        return simplifiedList;
    }

    public static List<WeaponRecipeIngredient> MultiplyItemCount(List<WeaponRecipeIngredient> recipeDecomposes, float multiplier)
    {
        var multipliedList = recipeDecomposes.Select(ingredient => new WeaponRecipeIngredient
        {
            itemProfile = ingredient.itemProfile,
            itemCount = (int)Math.Ceiling(ingredient.itemCount * multiplier)
        }).ToList();

        return multipliedList;
    }
}
