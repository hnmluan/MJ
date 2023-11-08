

using System;

[Serializable]
public class ItemInventoryData
{
    public string itemCode;
    public int itemCount;
    public int maxStack;

    public ItemInventory ToItemInventory()
    {
        ItemInventory item = new ItemInventory();
        item.maxStack = maxStack;
        item.itemCount = itemCount;
        item.itemProfile = ItemDataSO.FindByItemCode(ItemCodeParser.FromString(itemCode));
        return item;
    }
}
