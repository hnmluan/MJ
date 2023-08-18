using UnityEngine;

public class RecipeUpgradeLevelUISpawner : Spawner
{
    private static RecipeUpgradeLevelUISpawner instance;
    public static RecipeUpgradeLevelUISpawner Instance => instance;

    public static string recipeUpdateLevelUI = "RecipeUpgradeLevelUI";

    protected override void Awake()
    {
        base.Awake();
        if (RecipeUpgradeLevelUISpawner.instance != null) Debug.LogError("Only 1 UIArmoryItemSpawner allow to exist");
        RecipeUpgradeLevelUISpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = this.transform.parent;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    public virtual void ClearRecipeUpdateLevelUI()
    {
        foreach (Transform weapon in this.holder) this.Despawn(weapon);
    }

    public virtual void SpawnRecipeUpdateLevelUI(WeaponRecipeIngredient weaponRecipeIngredient)
    {
        Transform uiWeapon = this.Spawn(RecipeUpgradeLevelUISpawner.recipeUpdateLevelUI, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIRecipeUpgradeLevel uiRecipeUpdateLevel = uiWeapon.GetComponent<UIRecipeUpgradeLevel>();
        uiRecipeUpdateLevel.ShowUIRecipeUpdateLevel(weaponRecipeIngredient);

        uiWeapon.gameObject.SetActive(true);
    }

    public virtual void SpawnRecipeUpdateLevelUI(WeaponRecipePrice weaponRecipePrice)
    {
        Transform uiWeapon = this.Spawn(RecipeUpgradeLevelUISpawner.recipeUpdateLevelUI, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIRecipeUpgradeLevel uiRecipeUpdateLevel = uiWeapon.GetComponent<UIRecipeUpgradeLevel>();
        uiRecipeUpdateLevel.ShowUIRecipeUpdateLevel(weaponRecipePrice);

        uiWeapon.gameObject.SetActive(true);
    }
}
