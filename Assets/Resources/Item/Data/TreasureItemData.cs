using System;
using System.Collections.Generic;

[Serializable]

public class TreasureItemData : ItemData
{
    public ItemDataSO key;

    public List<ItemDropRate> listItemDrop;
}
