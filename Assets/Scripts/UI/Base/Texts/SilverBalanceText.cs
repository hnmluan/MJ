public class SilverBalanceText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText() => text.text = "x " + Wallet.Instance.SilverBalance.ToString();
}
