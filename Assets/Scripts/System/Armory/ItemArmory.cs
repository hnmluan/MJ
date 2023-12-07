using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ItemArmory
{
    public WeaponDataSO weaponProfile;

    public int level = 0;

    public int position = 0;

    public bool isFocus = false;

    public ItemArmory(WeaponDataSO weaponProfile, int level)
    {
        this.weaponProfile = weaponProfile;
        this.level = level;
    }

    public ItemArmory(WeaponData data)
    {
        this.weaponProfile = WeaponDataSO.FindByName(data.itemCode);
        this.level = data.level;
        this.position = data.position;
        this.isFocus = false;
    }

    public bool CanUpgrade()
    {
        if (level >= weaponProfile.levels.Count) return false;
        return weaponProfile.levels[level].weaponRecipe.isAvailable();
    }

    public bool Upgrade()
    {
        if (!CanUpgrade()) return false;

        foreach (WeaponRecipeIngredient item in weaponProfile.levels[level].weaponRecipe.recipeIngredients)
            Inventory.Instance.DeductItem(item.itemProfile.itemCode, item.itemCount);

        foreach (WeaponRecipePrice item in weaponProfile.levels[level].weaponRecipe.recipePrice)
        {
            if (item.data.currencyCode == CurrencyCode.Gold) Wallet.Instance.DeductGold(item.quantity);
            if (item.data.currencyCode == CurrencyCode.Silver) Wallet.Instance.DeductSilver(item.quantity);
        }

        level++;

        return true;
    }

    public void Decompose()
    {
        foreach (WeaponRecipeIngredient recipeDecompose in GetRecipeDecompose())
            Inventory.Instance.AddItem(recipeDecompose.itemProfile.itemCode, recipeDecompose.itemCount);

        Armory.Instance.DeductItem(this);
    }

    public List<WeaponRecipeIngredient> GetRecipeDecompose()
    {
        try
        {
            List<WeaponRecipeIngredient> recipeDecomposes = new List<WeaponRecipeIngredient>();

            for (int i = 0; i < level; i++) recipeDecomposes.AddRange(this.weaponProfile.levels[i].weaponRecipe.recipeIngredients);

            recipeDecomposes = SimplifyRecipe(recipeDecomposes);

            recipeDecomposes = MultiplyItemCount(recipeDecomposes, Armory.ratioDecompose);

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
