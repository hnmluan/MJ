using System;
using System.Collections.Generic;

[Serializable]

public class SellItemData : ItemData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;
}
