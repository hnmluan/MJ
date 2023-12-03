using Assets.SimpleLocalization;
using System.Collections.Generic;

public class UIArmoryDetail : UIArmoryDetailAbstract
{
    protected ItemArmory weapon => UIArmory.Instance.CurrentItem;

    public virtual void Show(ItemArmory weapon)
    {
        Clear(); if (weapon == null) return;

        uiArmoryDetailCtrl.WeaponImage.sprite = weapon.weaponProfile.spriteInHand;
        uiArmoryDetailCtrl.WeaponName.text = LocalizationManager.Localize(weapon.weaponProfile.keyName);
        uiArmoryDetailCtrl.WeaponLevel.text = "+ " + weapon.level.ToString();
        uiArmoryDetailCtrl.WeaponType.text = LocalizationManager.Localize("Weapon.Type." + weapon.weaponProfile.damageObjectType.ToString());

        this.ShowUpgradeText();
        this.ShowUpgradeRecipeIngredient();
        this.ShowUpgradeRecipePrice();
        this.ShowButtons();
    }

    public virtual void Clear()
    {
        uiArmoryDetailCtrl.WeaponImage.sprite = null;
        uiArmoryDetailCtrl.WeaponName.text = "";
        uiArmoryDetailCtrl.WeaponLevel.text = "";
        uiArmoryDetailCtrl.WeaponType.text = "";
        uiArmoryDetailCtrl.WeaponUpgrade.text = "";
        uiArmoryDetailCtrl.BtnDecompose.gameObject.SetActive(false);
        uiArmoryDetailCtrl.BtnUpgradeWeapon.gameObject.SetActive(false);
        RecipeUpgradeSpawner.Instance.Clear();
    }

    private void ShowUpgradeRecipeIngredient()
    {
        if (weapon.weaponProfile.levels.Count <= weapon.level) return;

        int numberOfUpdateRecipeIngredient = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipeIngredients.Count;

        if (numberOfUpdateRecipeIngredient == 0) return;

        List<WeaponRecipeIngredient> recipeIngredients = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipeIngredients;

        for (int i = 0; i < numberOfUpdateRecipeIngredient; i++) RecipeUpgradeSpawner.Instance.Spawn(recipeIngredients[i]);
    }

    private void ShowUpgradeRecipePrice()
    {
        if (weapon.weaponProfile.levels.Count <= weapon.level) return;

        int numberOfUpdateRecipePrice = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipePrice.Count;

        if (numberOfUpdateRecipePrice == 0) return;

        List<WeaponRecipePrice> recipePrices = weapon.weaponProfile.levels[weapon.level - 1].weaponRecipe.recipePrice;

        for (int i = 0; i < numberOfUpdateRecipePrice; i++) RecipeUpgradeSpawner.Instance.Spawn(recipePrices[i]);
    }

    private void ShowUpgradeText() =>
        uiArmoryDetailCtrl.WeaponUpgrade.text = weapon.weaponProfile.levels.Count > weapon.level
        ? LocalizationManager.Localize("Armory.upgrade") : LocalizationManager.Localize("Armory.upgradeMax");

    private void ShowButtons()
    {
        uiArmoryDetailCtrl.BtnDecompose.gameObject.SetActive(true);
        uiArmoryDetailCtrl.BtnUpgradeWeapon.gameObject.SetActive(weapon.weaponProfile.levels.Count > weapon.level);
    }
}
