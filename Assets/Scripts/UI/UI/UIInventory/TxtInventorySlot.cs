public class TxtInventorySlot : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateSlot();

    protected virtual void UpdateSlot()
    {
        int currentSlotText = PlayerCtrl.Instance.Inventory.GetCurrentSlot();
        int maxSlotText = PlayerCtrl.Instance.Inventory.MaxSlot;
        this.text.text = currentSlotText + " / " + maxSlotText;
    }
}
