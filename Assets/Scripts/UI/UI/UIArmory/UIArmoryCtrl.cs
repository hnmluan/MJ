using UnityEngine;

public class UIArmoryCtrl : InitMonoBehaviour
{
    private static UIArmoryCtrl instance;
    public static UIArmoryCtrl Instance => instance;

    [Header("Armory Weapon Spawner")]
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIArmoryItemSpawner armoryWeaponSpawner;
    public UIArmoryItemSpawner UIArmoryWeaponSpawner => armoryWeaponSpawner;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmoryCtrl.instance != null) Debug.LogError("Only 1 UIArmoryCtrl allow to exist");
        UIArmoryCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIArmoryWeaponSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIArmoryWeaponSpawner()
    {
        if (this.armoryWeaponSpawner != null) return;
        this.armoryWeaponSpawner = transform.GetComponentInChildren<UIArmoryItemSpawner>();
        Debug.Log(transform.name + ": LoadUIArmoryWeaponSpawner", gameObject);
    }
}