using System;


[Serializable]
public class ItemInventory
{
    public string itemId;
    public ItemCode itemCode;
    public int itemCount = 0;
    public int maxStack = 30;

    public ItemDataSO itemProfile() => ItemDataSO.FindByItemCode(this.itemCode);

    public static string RandomId() => RandomStringGenerator.Generate(27);

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemId = ItemInventory.RandomId(),
            itemCode = this.itemCode,
            itemCount = this.itemCount,
        };
        return item;
    }
}