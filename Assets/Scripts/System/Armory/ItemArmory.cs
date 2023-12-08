using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ItemArmory
{
    public Weapon weapon;

    public int position = 0;

    public bool isFocus = false;

    public ItemArmory(WeaponCode code, int level)
    {
        this.weapon = new Weapon(WeaponDataSO.FindByCode(code), level);
        this.position = 0;
        this.isFocus = false;
    }

    public ItemArmory(ItemArmoryData data)
    {
        this.weapon = new Weapon(data.weapon);
        this.position = data.position;
        this.isFocus = false;
    }

    public bool CanUpgrade()
    {
        if (weapon.level >= weapon.dataSO.levels.Count) return false;
        return weapon.dataSO.levels[weapon.level].weaponRecipe.isAvailable();
    }

    public bool Upgrade()
    {
        if (!CanUpgrade()) return false;

        foreach (WeaponRecipeIngredient item in weapon.dataSO.levels[weapon.level].weaponRecipe.recipeIngredients)
            Inventory.Instance.DeductItem(item.itemProfile.itemCode, item.itemCount);

        foreach (WeaponRecipePrice item in weapon.dataSO.levels[weapon.level].weaponRecipe.recipePrice)
        {
            if (item.data.currencyCode == CurrencyCode.Gold) Wallet.Instance.DeductGold(item.quantity);
            if (item.data.currencyCode == CurrencyCode.Silver) Wallet.Instance.DeductSilver(item.quantity);
        }

        weapon.level++;

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

            for (int i = 0; i < weapon.level; i++) recipeDecomposes.AddRange(this.weapon.dataSO.levels[i].weaponRecipe.recipeIngredients);

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
