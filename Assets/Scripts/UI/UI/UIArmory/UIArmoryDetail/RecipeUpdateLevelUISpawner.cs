using UnityEngine;

public class RecipeUpdateLevelUISpawner : Spawner
{
    private static RecipeUpdateLevelUISpawner instance;
    public static RecipeUpdateLevelUISpawner Instance => instance;

    public static string recipeUpdateLevelUI = "RecipeUpdateLevelUI";

    protected override void Awake()
    {
        base.Awake();
        if (RecipeUpdateLevelUISpawner.instance != null) Debug.LogError("Only 1 UIArmoryItemSpawner allow to exist");
        RecipeUpdateLevelUISpawner.instance = this;
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
        Transform uiWeapon = this.Spawn(RecipeUpdateLevelUISpawner.recipeUpdateLevelUI, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIRecipeUpdateLevel uiRecipeUpdateLevel = uiWeapon.GetComponent<UIRecipeUpdateLevel>();
        uiRecipeUpdateLevel.ShowUIRecipeUpdateLevel(weaponRecipeIngredient);

        uiWeapon.gameObject.SetActive(true);
    }
}
