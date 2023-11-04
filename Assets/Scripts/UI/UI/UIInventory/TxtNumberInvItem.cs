public class TxtNumberInvItem : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateSlot();

    protected virtual void UpdateSlot()
    {
        int currentItem = Inventory.Instance.GetCurrentItemCount();
        int maxItem = Inventory.Instance.MaxItemCount;
        this.text.text = currentItem + " / " + maxItem;
    }
}
