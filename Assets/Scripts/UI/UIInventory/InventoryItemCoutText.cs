public class InventoryItemCoutText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateSlot();

    protected virtual void UpdateSlot()
    {
        int currentItem = PlayerCtrl.Instance.Inventory.GetCurrentItemCount();
        int maxItem = PlayerCtrl.Instance.Inventory.MaxItemCout;
        this.text.text = currentItem + " / " + maxItem;
    }
}
