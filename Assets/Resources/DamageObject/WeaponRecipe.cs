
using System;
using System.Collections.Generic;

[Serializable]

public class WeaponRecipe
{
    public List<WeaponRecipeIngredient> recipeIngredients;

    public List<WeaponRecipePrice> recipePrice;

    public bool isAvailable()
    {
        foreach (WeaponRecipeIngredient item in recipeIngredients) if (!item.isAvailable()) return false;

        foreach (WeaponRecipePrice item in recipePrice) if (!item.isAvailable()) return false;

        return true;
    }
}
