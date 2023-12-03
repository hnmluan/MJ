using UnityEngine;

public class RecipeDecomposeUISpawner : Spawner
{
    public static string recipeUpdateLevelUI = "Item";

    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void ClearRecipeDecomposeLevelUI() { foreach (Transform weapon in this.holder) this.Despawn(weapon); }

    public virtual void SpawnRecipeDecomposeItemUI(WeaponRecipeIngredient weaponRecipeIngredient)
    {
        Transform uiWeapon = this.Spawn(RecipeDecomposeUISpawner.recipeUpdateLevelUI, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIItemRecipeDescompose uiRecipeUpdateLevel = uiWeapon.GetComponent<UIItemRecipeDescompose>();
        uiRecipeUpdateLevel.ShowItem(weaponRecipeIngredient);

        uiWeapon.gameObject.SetActive(true);
    }
}
