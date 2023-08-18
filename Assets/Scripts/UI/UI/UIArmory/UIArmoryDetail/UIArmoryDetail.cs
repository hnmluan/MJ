using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;

public class UIArmoryDetail : UIArmoryDetailAbstract
{
    [Header("UI Armory Detail")]

    private static UIArmoryDetail instance;
    public static UIArmoryDetail Instance => instance;

    [SerializeField] protected Weapon weapon = null;
    public Weapon Weapon => weapon;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmoryDetail.instance != null) Debug.LogError("Only 1 UIArmory allow to exist");
        UIArmoryDetail.instance = this;
    }

    protected override void OnDisable() => this.SetEmptyUIArmoryDetail();

    public virtual void SetUIArmoryDetail(Weapon weapon)
    {
        SetEmptyUIArmoryDetail();

        this.weapon = weapon;

        uiArmoryDetailCtrl.WeaponImage.sprite = weapon.weaponProfile.spriteInHand;
        uiArmoryDetailCtrl.WeaponName.text = LocalizationManager.Localize(weapon.weaponProfile.keyName);
        uiArmoryDetailCtrl.WeaponLevel.text = "+ " + weapon.level.ToString();
        uiArmoryDetailCtrl.WeaponType.text = LocalizationManager.Localize("Weapon.Type." + weapon.weaponProfile.damageObjectType.ToString());

        this.ShowUpgradeText();
        this.ShowUpgradeRecipeIngredient();
        this.ShowUpgradeRecipePrice();
    }

    public virtual void SetEmptyUIArmoryDetail()
    {
        this.weapon = null;
        uiArmoryDetailCtrl.WeaponImage.sprite = null;
        uiArmoryDetailCtrl.WeaponName.text = "";
        uiArmoryDetailCtrl.WeaponLevel.text = "";
        uiArmoryDetailCtrl.WeaponType.text = "";
        uiArmoryDetailCtrl.WeaponUpgrade.text = "";

        RecipeUpgradeLevelUISpawner.Instance.ClearRecipeUpdateLevelUI();
    }

    private void ShowUpgradeRecipeIngredient()
    {
        if (weapon.weaponProfile.levels.Count <= weapon.level) return;

        int numberOfUpdateRecipeIngredient = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipeIngredients.Count;

        if (numberOfUpdateRecipeIngredient == 0) return;

        List<WeaponRecipeIngredient> recipeIngredients = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipeIngredients;

        for (int i = 0; i < numberOfUpdateRecipeIngredient; i++) RecipeUpgradeLevelUISpawner.Instance.SpawnRecipeUpdateLevelUI(recipeIngredients[i]);
    }

    private void ShowUpgradeRecipePrice()
    {
        if (weapon.weaponProfile.levels.Count <= weapon.level) return;

        int numberOfUpdateRecipePrice = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipePrice.Count;

        if (numberOfUpdateRecipePrice == 0) return;

        List<WeaponRecipePrice> recipePrices = weapon.weaponProfile.levels[weapon.level - 1].weaponRecipe.recipePrice;

        for (int i = 0; i < numberOfUpdateRecipePrice; i++) RecipeUpgradeLevelUISpawner.Instance.SpawnRecipeUpdateLevelUI(recipePrices[i]);
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
}
