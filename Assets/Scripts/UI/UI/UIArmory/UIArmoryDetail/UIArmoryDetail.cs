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
        this.weapon = weapon;

        uiArmoryDetailCtrl.WeaponImage.sprite = weapon.weaponProfile.spriteInHand;
        uiArmoryDetailCtrl.WeaponName.text = LocalizationManager.Localize(weapon.weaponProfile.keyName);
        uiArmoryDetailCtrl.WeaponLevel.text = "+ " + weapon.level.ToString();
        uiArmoryDetailCtrl.WeaponType.text = LocalizationManager.Localize("Weapon.Type." + weapon.weaponProfile.damageObjectType.ToString());

        int numberOfUpdateRecipeIngredient = weapon.weaponProfile.levels[weapon.level].weaponRecipe.recipeIngredients.Count;

        List<WeaponRecipeIngredient> recipeIngredients = weapon.weaponProfile.levels[weapon.level - 1].weaponRecipe.recipeIngredients;

        for (int i = 0; i < numberOfUpdateRecipeIngredient; i++)
        {
            RecipeUpdateLevelUISpawner.Instance.SpawnRecipeUpdateLevelUI(recipeIngredients[i]);
        }
    }

    public virtual void SetEmptyUIArmoryDetail()
    {
        this.weapon = null;
        uiArmoryDetailCtrl.WeaponImage.sprite = null;
        uiArmoryDetailCtrl.WeaponName.text = "";
        uiArmoryDetailCtrl.WeaponLevel.text = "";
        uiArmoryDetailCtrl.WeaponType.text = "";

        RecipeUpdateLevelUISpawner.Instance.ClearRecipeUpdateLevelUI();
    }
}
