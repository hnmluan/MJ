using System;
using System.Collections.Generic;

[Serializable]

public class BuyableItemData : ItemData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;
}
