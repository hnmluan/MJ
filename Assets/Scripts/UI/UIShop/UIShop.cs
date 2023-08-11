using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : InitMonoBehaviour
{
    [Header("UI Shop")]
    private static UIShop instance;
    public static UIShop Instance => instance;

    [SerializeField] private List<ItemInventory> listItemToSale;
    public List<ItemInventory> ListItemToSale => listItemToSale;

    [SerializeField] private DateTime timelineToRestItem;
    public DateTime TimelineToRestItem => timelineToRestItem;

    [SerializeField] private int intervalRestItem;
    public int IntervalRestItem => intervalRestItem;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIShop.instance != null) Debug.LogError("Only 1 UIShop allow to exist");
        UIShop.instance = this;
    }

    protected override void Start()
    {
        listItemToSale = new List<ItemInventory>(PlayerCtrl.Instance.Inventory.Items);
        this.ResetItemInShop();
        timelineToRestItem = DateTime.Now;

        base.Start();
        this.Close();
    }

    private void Update() => CheckTimeToResetItem();

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

    public virtual void ResetItemInShop()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        foreach (ItemInventory item in ListItemToSale) UIShopItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIShopItemSpawner.Instance.ClearItems();

    private void CheckTimeToResetItem()
    {
        if (GetDeltaTimeReset() > intervalRestItem)
        {
            ResetItemInShop();
            UpdateTimelineToRestItem();
        }
    }

    private void UpdateTimelineToRestItem()
    {
        int times = GetDeltaTimeReset() / intervalRestItem;
        timelineToRestItem = timelineToRestItem.AddSeconds(times * intervalRestItem);
    }

    public int GetDeltaTimeReset()
    {
        TimeSpan timeDifference = DateTime.Now - timelineToRestItem;
        int timeDifferenceInSeconds = (int)timeDifference.TotalSeconds;
        return timeDifferenceInSeconds;
    }
}
