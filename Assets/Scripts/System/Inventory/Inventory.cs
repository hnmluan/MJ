using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int maxSlot;
    public int MaxSlot { get => maxSlot; set => maxSlot = value; }

    [SerializeField] private int maxItemCount;
    public int MaxItemCount { get => maxItemCount; set => maxItemCount = value; }

    [SerializeField] private List<ItemInventory> items;
    public List<ItemInventory> Items { get => items; set => items = value; }

    protected override void Awake()
    {
        base.Awake();
        this.LoadData();
    }

    public void LoadData()
    {
        InventoryData inventoryData = SaveLoadHandler.LoadFromFile<InventoryData>(FileNameData.Inventory);

        if (inventoryData == null)
        {
            this.maxSlot = 10000;
            this.maxItemCount = 10000;
            AddItem(ItemCode.CopperSword, 100);
            return;
        };

        this.MaxSlot = inventoryData.maxSlot;
        this.MaxItemCount = inventoryData.maxItemCount;

        foreach (ItemInventoryData item in inventoryData.items) this.items.Add(item.ToItemInventory());
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Inventory, new InventoryData());

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        if (GetCurrentItemCount() + addCount > MaxItemCount) return false;

        ItemDataSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;

        for (int i = 0; i < this.MaxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return false;

                itemExist = this.CreateEmptyItem(itemProfile);
                this.Items.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        SaveData();
        return true;
    }

    protected virtual bool IsInventoryFull() => IsInventorySlotFull() || IsInventoryCountFull();

    public virtual bool IsInventorySlotFull() => GetCurrentSlot() >= this.MaxSlot;

    public virtual bool IsInventoryCountFull() => GetCurrentItemCount() >= this.MaxItemCount;

    public virtual int GetCurrentSlot() => this.Items.Count;

    public virtual int GetCurrentItemCount()
    {
        int itemCout = 0;
        foreach (ItemInventory item in Items) itemCout += item.itemCount;
        return itemCout;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemDataSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item/ScriptableObject/", typeof(ItemDataSO));
        foreach (ItemDataSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.Items)
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemDataSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.Items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }

        return totalCount;
    }

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.Items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.Items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }

            itemInventory.itemCount -= deduct;
        }
        RemoveEmptySlot();
        SaveData();
    }

    public virtual void RemoveEmptySlot() => Items.RemoveAll(item => item.itemCount == 0);

    public virtual int GetQuantity(ItemCode itemCode)
    {
        int quantity = 0;
        for (int i = 0; i < this.Items.Count; i++)
        {
            if (Items[i].itemProfile.itemCode == itemCode) quantity += Items[i].itemCount;
        }
        return quantity;
    }
}
