using UnityEngine;

public class RecipeUpgradeSpawner : Spawner
{
    private static RecipeUpgradeSpawner instance;
    public static RecipeUpgradeSpawner Instance => instance;

    public static string item = "Item";

    [SerializeField] protected Transform content;

    protected override void Awake()
    {
        base.Awake();
        if (RecipeUpgradeSpawner.instance != null) Debug.Log("Only 1 RecipeUpgradeSpawner allow to exist");
        RecipeUpgradeSpawner.instance = this;
    }

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void Clear() { foreach (Transform weapon in this.holder) this.Despawn(weapon); }

    public virtual void Spawn(WeaponRecipeIngredient ingredient)
    {
        Transform uiWeapon = this.Spawn(RecipeUpgradeSpawner.item, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIRecipeUpgrade uiRecipeUpdateLevel = uiWeapon.GetComponent<UIRecipeUpgrade>();
        uiRecipeUpdateLevel.Show(ingredient);

        uiWeapon.gameObject.SetActive(true);
    }

    public virtual void Spawn(WeaponRecipePrice price)
    {
        Transform uiWeapon = this.Spawn(RecipeUpgradeSpawner.item, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIRecipeUpgrade uiRecipeUpdateLevel = uiWeapon.GetComponent<UIRecipeUpgrade>();
        uiRecipeUpdateLevel.Show(price);

        uiWeapon.gameObject.SetActive(true);
    }
}
