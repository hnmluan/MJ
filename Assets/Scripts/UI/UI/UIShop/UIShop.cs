using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : Singleton<UIShop>
{
    [SerializeField] private DateTime lastTimeRestItem;
    public DateTime TimelineToRestItem => lastTimeRestItem;

    [SerializeField] private int intervalRestItem = 100;
    public int IntervalRestItem => intervalRestItem;

    [SerializeField] private int numberOfItems = 10;
    public int NumberOfItems => numberOfItems;

    protected override void Start()
    {
        this.ResetItems();
        lastTimeRestItem = DateTime.Now;
        ItemDataSO.FindByItemCode(ItemCode.NoItem);

        base.Start();
    }

    private void Update() => CheckTimeToResetItem();

    public virtual void ResetItems()
    {
        if (ItemDataSO.GetSellableItemsSO().Count == 0) return;

        this.ClearItems();

        foreach (ItemShop item in GetRandomNumberList(numberOfItems)) UIShopItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIShopItemSpawner.Instance.ClearItems();

    private void CheckTimeToResetItem()
    {
        if (GetDeltaTimeReset() > intervalRestItem)
        {
            ResetItems();
            UpdateTimelineToRestItem();
        }
    }

    private void UpdateTimelineToRestItem()
    {
        int times = GetDeltaTimeReset() / intervalRestItem;

        UpdateLastTimeRestItem(lastTimeRestItem.AddSeconds(times * intervalRestItem));
    }

    public void UpdateLastTimeRestItem(DateTime time) => this.lastTimeRestItem = time;

    public int GetDeltaTimeReset()
    {
        TimeSpan timeDifference = DateTime.Now - lastTimeRestItem;
        int timeDifferenceInSeconds = (int)timeDifference.TotalSeconds;
        return timeDifferenceInSeconds;
    }

    public static List<ItemShop> GetRandomNumberList(int quantity)
    {
        List<ItemShop> listItemShop = new List<ItemShop>();

        for (int i = 0; i < quantity; i++)
        {
            ItemShop randomItemShop = ItemShop.GetRandomSellableItem();
            listItemShop.Add(randomItemShop);
        }

        return listItemShop;
    }
}
