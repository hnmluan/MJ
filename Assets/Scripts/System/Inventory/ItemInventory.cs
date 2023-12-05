using System;


[Serializable]
public class ItemInventory
{
    public ItemDataSO itemProfile;
    public int itemCount;
    public int maxStack;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
        };
        return item;
    }
}