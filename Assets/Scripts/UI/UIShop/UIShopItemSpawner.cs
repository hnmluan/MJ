using UnityEngine;

public class UIShopItemSpawner : Spawner
{
    private static UIShopItemSpawner instance;
    public static UIShopItemSpawner Instance => instance;
    public static string normalItem = "UIShopItem";

    [Header("Shop Item Spawner")]
    [SerializeField] protected UIShopCtrl shopCtrl;
    public UIShopCtrl UIShopCtrl => shopCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIShopItemSpawner.instance != null) Debug.LogError("Only 1 UIShopItemSpawner allow to exist");
        UIShopItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIShopCtrl();

        if (this.holder != null) return;
        this.holder = this.shopCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    protected virtual void LoadUIShopCtrl()
    {
        if (this.shopCtrl != null) return;
        this.shopCtrl = transform.parent.GetComponent<UIShopCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIShopCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach (Transform item in this.holder) this.Despawn(item);
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.shopCtrl.UIShopItemSpawner.Spawn(UIShopItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemShop itemShop = uiItem.GetComponent<UIItemShop>();
        itemShop.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}