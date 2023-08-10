using System;
[Serializable]
public class ItemInventory
{
    public string itemId;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 30;
    public int upgradeLevel = 0;

    public static string RandomId() => RandomStringGenerator.Generate(27);

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemId = ItemInventory.RandomId(),
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };
        return item;
    }
}