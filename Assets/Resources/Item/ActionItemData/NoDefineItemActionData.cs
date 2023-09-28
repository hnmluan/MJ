using System;
using System.Collections.Generic;

[Serializable]
public class NoDefineItemActionData : ItemActionData
{
    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;

    public override void Action() => Wallet.Instance.AddGoldenBalance(this.quantityToBuy.GetRandomValue());

    protected override void SetKeyActionLocalization() => this.KeyActionLocalization = "Drop";
}
