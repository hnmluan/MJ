public class TxtGoldBalance : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText() => text.text = "x " + Wallet.Instance.GoldenBalance.ToString();
}
