﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;

    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    [SerializeField] protected ItemType inventoryFilter = ItemType.NoType;

    public void SetInventorySort(InventorySort inventorySort) => this.inventorySort = inventorySort;
    public void SetInventoryFilter(ItemType inventoryFilter) => this.inventoryFilter = inventoryFilter;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();

        InvokeRepeating(nameof(this.ShowItems), 1, 1);
        // this.ShowItems();
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.inventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.Inventory.Items;

        items = inventoryFilter == ItemType.NoType ? items : items.Where(item => item.itemProfile.itemType == inventoryFilter).ToList();

        UIInvItemSpawner spawner = this.inventoryCtrl.UIInvItemSpawner;

        foreach (ItemInventory item in items) spawner.SpawnItem(item);

        this.SortItems();
    }

    protected virtual void ClearItems()
    {
        this.inventoryCtrl.UIInvItemSpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = this.inventoryCtrl.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = this.inventoryCtrl.Content.GetChild(i);
            Transform nextItem = this.inventoryCtrl.Content.GetChild(i + 1);

            UIItemInventory currentUIItem = currentItem.GetComponent<UIItemInventory>();
            UIItemInventory nextUIItem = nextItem.GetComponent<UIItemInventory>();

            ItemProfileSO currentProfile = currentUIItem.ItemInventory.itemProfile;
            ItemProfileSO nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    string currentName = currentProfile.itemName;
                    string nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1; // Đổi từ -1 thành 1 để đảo ngược thứ tự
                    break;
                case InventorySort.ByQuantity:
                    int currentCount = currentUIItem.ItemInventory.itemCount;
                    int nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount < nextCount; // Đổi dấu > thành <
                    break;
            }

            if (isSwap)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting)
        {
            this.SortItems(); // Gọi đệ quy chỉ khi có sự thay đổi
        }
    }



    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

}
