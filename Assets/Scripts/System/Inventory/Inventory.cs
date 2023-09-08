using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int maxSlot = 100;
    public int MaxSlot => maxSlot;

    [SerializeField] private int maxItemCout = 100;
    public int MaxItemCout => maxItemCout;

    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;

    protected override void Start()
    {
        /*        this.AddItem(ItemCode.IronOre, 100);
                this.AddItem(ItemCode.GoldOre, 100);
                this.AddItem(ItemCode.CopperSword, 100);
                this.AddItem(ItemCode.GoldenTreasure, 100);
                this.AddItem(ItemCode.GoldCup, 100);
                this.AddItem(ItemCode.SilverCup, 100);
                this.AddItem(ItemCode.SilverTreasure, 100);
                this.AddItem(ItemCode.SilverKey, 100);
                this.AddItem(ItemCode.GoldKey, 100);*/
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        if (GetCurrentItemCount() + addCount > maxItemCout) return false;

        ItemDataSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;

        for (int i = 0; i < this.maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return false;

                itemExist = this.CreateEmptyItem(itemProfile);
                this.items.Add(itemExist);
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

        return true;
    }

    protected virtual bool IsInventoryFull() => IsInventorySlotFull() || IsInventoryCoutFull();

    public virtual bool IsInventorySlotFull() => GetCurrentSlot() >= this.maxSlot;

    public virtual bool IsInventoryCoutFull() => GetCurrentItemCount() >= this.maxItemCout;

    public virtual int GetCurrentSlot() => this.items.Count;

    public virtual int GetCurrentItemCount()
    {
        int itemCout = 0;
        foreach (ItemInventory item in items) itemCout += item.itemCount;
        return itemCout;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual ItemDataSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item/SO/", typeof(ItemDataSO));
        foreach (ItemDataSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
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
            itemId = ItemInventory.RandomId(),
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
        foreach (ItemInventory itemInventory in this.items)
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
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
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
    }

    public virtual void RemoveEmptySlot() => items.RemoveAll(item => item.itemCount == 0);


    public virtual int GetQuantity(ItemCode itemCode)
    {
        int quantity = 0;
        for (int i = 0; i < this.items.Count; i++)
        {
            if (items[i].itemProfile.itemCode == itemCode) quantity += items[i].itemCount;
        }
        return quantity;
    }
}
