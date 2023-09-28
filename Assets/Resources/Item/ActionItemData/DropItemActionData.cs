using System;

[Serializable]

public class DropItemActionData : ItemActionData
{
    public int price;

    public override void Action()
    {
        Wallet.Instance.AddSilverBalance(this.price);
        UITextSpawner.Instance.SpawnUITextWithMousePosition("X " + price.ToString());
    }

    protected override void SetKeyActionLocalization() => this.KeyActionLocalization = "Drop";
}
