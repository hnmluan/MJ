using UnityEngine;

public class UIArmoryItemSpawner : Spawner
{
    private static UIArmoryItemSpawner instance;
    public static UIArmoryItemSpawner Instance => instance;

    public static string normalWeapon = "UIItem";

    protected override void Awake()
    {
        base.Awake();
        if (UIArmoryItemSpawner.instance != null) Debug.Log("Only 1 UIArmoryItemSpawner allow to exist");
        UIArmoryItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = UIArmory.Instance.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    public virtual void ClearWeapons()
    {
        foreach (Transform weapon in this.holder) this.Despawn(weapon);
    }

    public virtual void SpawnWeapon(ItemArmory weapon)
    {
        Transform uiWeapon = this.Spawn(UIArmoryItemSpawner.normalWeapon, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIItemArmory Weapon = uiWeapon.GetComponent<UIItemArmory>();
        Weapon.ShowWeapon(weapon);

        uiWeapon.gameObject.SetActive(true);
    }
}