using Assets.SimpleLocalization;
using System.Collections.Generic;

public class UIArmoryDetail : UIArmoryDetailAbstract
{
    protected ItemArmory weapon => UIArmory.Instance.CurrentItem;

    public virtual void Show()
    {
        Clear(); if (weapon == null) return;

        uiArmoryDetailCtrl.Image.sprite = weapon.weapon.dataSO.spriteInHand;
        uiArmoryDetailCtrl.Name.text = LocalizationManager.Localize(weapon.weapon.dataSO.keyName);
        uiArmoryDetailCtrl.Level.text = "+ " + weapon.weapon.level.ToString();
        uiArmoryDetailCtrl.Type.text = LocalizationManager.Localize("Weapon.Type." + weapon.weapon.dataSO.damageObjectType.ToString());

        this.ShowUpgradeText();
        this.ShowUpgradeRecipeIngredient();
        this.ShowUpgradeRecipePrice();
        this.ShowButtons();
        this.ShowEquippWeaponSlot();
    }

    public virtual void Clear()
    {
        uiArmoryDetailCtrl.Image.sprite = null;
        uiArmoryDetailCtrl.Name.text = "";
        uiArmoryDetailCtrl.Level.text = "";
        uiArmoryDetailCtrl.Type.text = "";
        uiArmoryDetailCtrl.UpgradeTxt.text = "";
        uiArmoryDetailCtrl.BtnDecompose.gameObject.SetActive(false);
        uiArmoryDetailCtrl.BtnUpgrade.gameObject.SetActive(false);
        uiArmoryDetailCtrl.SlotEquippedWeaponBox.gameObject.SetActive(false);
        RecipeUpgradeSpawner.Instance.Clear();
    }

    private void ShowUpgradeRecipeIngredient()
    {
        if (weapon.weapon.dataSO.levels.Count <= weapon.weapon.level) return;

        int numberOfUpdateRecipeIngredient = weapon.weapon.dataSO.levels[weapon.weapon.level].weaponRecipe.recipeIngredients.Count;

        if (numberOfUpdateRecipeIngredient == 0) return;

        List<WeaponRecipeIngredient> recipeIngredients = weapon.weapon.dataSO.levels[weapon.weapon.level].weaponRecipe.recipeIngredients;

        for (int i = 0; i < numberOfUpdateRecipeIngredient; i++) RecipeUpgradeSpawner.Instance.Spawn(recipeIngredients[i]);
    }

    private void ShowUpgradeRecipePrice()
    {
        if (weapon.weapon.dataSO.levels.Count <= weapon.weapon.level) return;

        int numberOfUpdateRecipePrice = weapon.weapon.dataSO.levels[weapon.weapon.level].weaponRecipe.recipePrice.Count;

        if (numberOfUpdateRecipePrice == 0) return;

        List<WeaponRecipePrice> recipePrices = weapon.weapon.dataSO.levels[weapon.weapon.level - 1].weaponRecipe.recipePrice;

        for (int i = 0; i < numberOfUpdateRecipePrice; i++) RecipeUpgradeSpawner.Instance.Spawn(recipePrices[i]);
    }

    private void ShowUpgradeText() =>
        uiArmoryDetailCtrl.UpgradeTxt.text = weapon.weapon.dataSO.levels.Count > weapon.weapon.level
        ? LocalizationManager.Localize("Armory.upgrade") :
        LocalizationManager.Localize("Armory.upgradeMax");

    private void ShowButtons()
    {
        uiArmoryDetailCtrl.BtnDecompose.gameObject.SetActive(true);
        uiArmoryDetailCtrl.BtnUpgrade.gameObject.SetActive(weapon.weapon.dataSO.levels.Count > weapon.weapon.level);
        uiArmoryDetailCtrl.BtnEquip.gameObject.SetActive(weapon.position == 0);
        uiArmoryDetailCtrl.BtnUnequip.gameObject.SetActive(weapon.position != 0);
    }

    private void ShowEquippWeaponSlot()
    {
        uiArmoryDetailCtrl.SlotEquippedWeaponTxt.text = weapon.position.ToString();
        uiArmoryDetailCtrl.SlotEquippedWeaponBox.gameObject.SetActive(this.weapon.position != 0);
    }
}
