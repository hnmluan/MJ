﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShop : InitMonoBehaviour
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

    protected bool isOpen = true;

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

    public virtual void ResetItems()
    {
        if (!this.isOpen) return;
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