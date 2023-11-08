using System;


[Serializable]
public class ItemInventory
{
    public ItemDataSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 30;

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