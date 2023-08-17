using UnityEngine;

public class UIArmoryItemSpawner : Spawner
{
    private static UIArmoryItemSpawner instance;
    public static UIArmoryItemSpawner Instance => instance;

    public static string normalWeapon = "UIItem";

    [Header("Armory Weapon Spawner")]
    [SerializeField] protected UIArmoryCtrl armoryCtrl;
    public UIArmoryCtrl UIArmoryCtrl => armoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmoryItemSpawner.instance != null) Debug.LogError("Only 1 UIArmoryItemSpawner allow to exist");
        UIArmoryItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIArmoryCtrl();

        if (this.holder != null) return;
        this.holder = this.armoryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    protected virtual void LoadUIArmoryCtrl()
    {
        if (this.armoryCtrl != null) return;
        this.armoryCtrl = transform.parent.GetComponent<UIArmoryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIArmoryCtrl", gameObject);
    }

    public virtual void ClearWeapons()
    {
        foreach (Transform weapon in this.holder) this.Despawn(weapon);
    }

    public virtual void SpawnWeapon(Weapon weapon)
    {
        Transform uiWeapon = this.armoryCtrl.UIArmoryWeaponSpawner.Spawn(UIArmoryItemSpawner.normalWeapon, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIItemArmory Weapon = uiWeapon.GetComponent<UIItemArmory>();
        Weapon.ShowWeapon(weapon);

        uiWeapon.gameObject.SetActive(true);
    }
}