using System;
using System.Collections.Generic;

[Serializable]

public class ItemBuyActionData : ItemActionData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;

    public ItemBuyActionData()
    {
        this.price = new List<ItemRangePrice>
        {
            new ItemRangePrice(CurrencyDataSO.FindByCode(CurrencyCode.Silver), new IntRange(1, 10)),
            new ItemRangePrice(CurrencyDataSO.FindByCode(CurrencyCode.Gold), new IntRange(1, 10))
        };
        this.quantityToBuy = new IntRange(1, 10);
    }
}
