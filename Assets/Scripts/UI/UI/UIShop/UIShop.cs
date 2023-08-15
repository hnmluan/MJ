﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : BaseUI
{
    [Header("UI Shop")]
    private static UIShop instance;
    public static UIShop Instance => instance;

    [SerializeField] private DateTime lastTimeRestItem;
    public DateTime TimelineToRestItem => lastTimeRestItem;

    [SerializeField] private int intervalRestItem = 100;
    public int IntervalRestItem => intervalRestItem;

    [SerializeField] private int numberOfItems = 10;
    public int NumberOfItems => numberOfItems;

    protected override void Awake()
    {
        base.Awake();
        if (UIShop.instance != null) Debug.LogError("Only 1 UIShop allow to exist");
        UIShop.instance = this;
    }

    protected override void Start()
    {
        this.ResetItems();
        lastTimeRestItem = DateTime.Now;
        ItemProfileSO.FindByItemCode(ItemCode.NoItem);

        base.Start();
    }

    private void Update() => CheckTimeToResetItem();

    public virtual void ResetItems()
    {
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
            ItemShop randomItemShop = ItemShop.GetRandomItemShopExcludingNoItem();
            listItemShop.Add(randomItemShop);
        }

        return listItemShop;
    }
}
