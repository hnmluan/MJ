using UnityEngine;

public class RecipeDecomposeUISpawner : Spawner
{
    private static RecipeDecomposeUISpawner instance;
    public static RecipeDecomposeUISpawner Instance => instance;

    public static string recipeUpdateLevelUI = "UIItemRecipeDecompose";

    protected override void Awake()
    {
        base.Awake();
        if (RecipeDecomposeUISpawner.instance != null) Debug.LogError("Only 1 RecipeDecomposeUISpawner allow to exist");
        RecipeDecomposeUISpawner.instance = this;
    }
    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = this.transform.parent;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    public virtual void ClearRecipeDecomposeLevelUI()
    {
        foreach (Transform weapon in this.holder) this.Despawn(weapon);
    }

    public virtual void SpawnRecipeDecomposeItemUI(WeaponRecipeIngredient weaponRecipeIngredient)
    {
        Transform uiWeapon = this.Spawn(RecipeDecomposeUISpawner.recipeUpdateLevelUI, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIItemRecipeDescompose uiRecipeUpdateLevel = uiWeapon.GetComponent<UIItemRecipeDescompose>();
        uiRecipeUpdateLevel.ShowItem(weaponRecipeIngredient);

        uiWeapon.gameObject.SetActive(true);
    }
}
