using Assets.SimpleLocalization;
using System.Collections.Generic;

public class UIArmoryDetail : UIArmoryDetailAbstract
{
    protected ItemArmory weapon;
    public ItemArmory Weapon => weapon;

    protected override void OnDisable() => this.Clear();

    public virtual void Show(ItemArmory weapon)
    {
        Clear();

        this.weapon = weapon;

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
        this.weapon = null;
        uiArmoryDetailCtrl.WeaponImage.sprite = null;
        uiArmoryDetailCtrl.WeaponName.text = "";
        uiArmoryDetailCtrl.WeaponLevel.text = "";
        uiArmoryDetailCtrl.WeaponType.text = "";
        uiArmoryDetailCtrl.WeaponUpgrade.text = "";

        RecipeUpgradeSpawner.Instance.Clear();

        this.ShowButtons();
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

    private void ShowUpgradeText()
    {
        if (weapon.weaponProfile.levels.Count > weapon.level)
        {
            uiArmoryDetailCtrl.WeaponUpgrade.text = LocalizationManager.Localize("Armory.upgrade");
            return;
        };

        uiArmoryDetailCtrl.WeaponUpgrade.text = LocalizationManager.Localize("Armory.upgradeMax");
    }

    private void ShowButtons()
    {
        if (weapon == null)
        {
            uiArmoryDetailCtrl.BtnDecompose.gameObject.SetActive(false);
            uiArmoryDetailCtrl.BtnUpgradeWeapon.gameObject.SetActive(false);
            return;
        }
        uiArmoryDetailCtrl.BtnDecompose.gameObject.SetActive(true);
        uiArmoryDetailCtrl.BtnUpgradeWeapon.gameObject.SetActive(false);
        if (weapon.weaponProfile.levels.Count > weapon.level) uiArmoryDetailCtrl.BtnUpgradeWeapon.gameObject.SetActive(true);
    }
}
