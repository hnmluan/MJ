using System;

[Serializable]
public class ItemDropRate
{
    public ItemDataSO itemSO;
    public int dropRate;

    public ItemDropRate(ItemDataSO itemSO, int dropRate)
    {
        this.itemSO = itemSO;
        this.dropRate = dropRate;
    }
}
