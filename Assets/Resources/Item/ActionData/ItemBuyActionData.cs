using System;
using System.Collections.Generic;

[Serializable]

public class ItemBuyActionData : ItemActionData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;
}
