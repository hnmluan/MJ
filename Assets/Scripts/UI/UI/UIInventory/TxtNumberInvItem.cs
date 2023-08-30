public class TxtNumberInvItem : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateSlot();

    protected virtual void UpdateSlot()
    {
        int currentItem = Inventory.Ins.GetCurrentItemCount();
        int maxItem = Inventory.Ins.MaxItemCout;
        this.text.text = currentItem + " / " + maxItem;
    }
}
