using System;
using System.Collections.Generic;

[Serializable]

public class BuyItemData : ItemData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;
}
