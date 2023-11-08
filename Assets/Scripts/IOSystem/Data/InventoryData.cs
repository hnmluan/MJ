using System;
using System.Collections.Generic;

[Serializable]
public class InventoryData
{
    public int maxSlot;

    public int maxItemCount;

    public List<ItemInventoryData> items = new List<ItemInventoryData>();

    public InventoryData()
    {
        this.maxSlot = Inventory.Instance.MaxSlot;
        this.maxItemCount = Inventory.Instance.MaxItemCount;

        foreach (ItemInventory item in Inventory.Instance.Items)
        {
            ItemInventoryData data = new ItemInventoryData();
            data.itemCount = item.itemCount;
            data.maxStack = item.maxStack;
            data.itemCode = item.itemProfile.itemCode.ToString();
            items.Add(data);
        }
    }
}
