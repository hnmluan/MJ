using System;
[Serializable]
public class ItemDictionary
{
    public string itemId;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 30;
    public int upgradeLevel = 0;

    public static string RandomId() => RandomStringGenerator.Generate(27);

    public virtual ItemDictionary Clone()
    {
        ItemDictionary item = new ItemDictionary
        {
            itemId = ItemDictionary.RandomId(),
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };
        return item;
    }
}