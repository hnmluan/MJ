using System;
using System.Collections.Generic;

[Serializable]
public class BuyItemDataAction : ActionItemData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;

    protected override void Action() => Wallet.Instance.AddGoldenBalance(this.quantityToBuy.GetRandomValue());

    protected override void SetKeyActionLocalization() => this.KeyActionLocalization = "Drop";
}
