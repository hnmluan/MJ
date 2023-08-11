using UnityEngine;

public class UIShopCtrl : InitMonoBehaviour
{
    private static UIShopCtrl instance;
    public static UIShopCtrl Instance => instance;

    [Header("Shop Item Spawner")]
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIShopItemSpawner shopItemSpawner;
    public UIShopItemSpawner UIShopItemSpawner => shopItemSpawner;

    protected override void Awake()
    {
        base.Awake();
        if (UIShopCtrl.instance != null) Debug.LogError("Only 1 UIShopCtrl allow to exist");
        UIShopCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIShopItemSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIShopItemSpawner()
    {
        if (this.shopItemSpawner != null) return;
        this.shopItemSpawner = transform.GetComponentInChildren<UIShopItemSpawner>();
        Debug.Log(transform.name + ": LoadUIShopItemSpawner", gameObject);
    }
}