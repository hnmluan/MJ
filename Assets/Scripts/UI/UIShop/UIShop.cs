using System.Collections.Generic;
using UnityEngine;

public class UIShop : InitMonoBehaviour
{
    [Header("UI Shop")]
    private static UIShop instance;
    public static UIShop Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIShop.instance != null) Debug.LogError("Only 1 UIShop allow to exist");
        UIShop.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();

        InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        UIShopCtrl.Instance.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        UIShopCtrl.Instance.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = new List<ItemInventory>(PlayerCtrl.Instance.Inventory.Items);

        foreach (ItemInventory item in items) UIShopItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIShopItemSpawner.Instance.ClearItems();

}
