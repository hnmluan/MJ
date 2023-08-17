
using System;
using System.Collections.Generic;

[Serializable]

public class WeaponRecipe
{
    public int level;

    public List<WeaponRecipeIngredient> recipeIngredients;

    public List<WeaponRecipePrice> recipePrice;

    public int damage;
}
