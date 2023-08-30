public class TxtInventorySlot : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateSlot();

    protected virtual void UpdateSlot()
    {
        int currentSlotText = Inventory.Ins.GetCurrentSlot();
        int maxSlotText = Inventory.Ins.MaxSlot;
        this.text.text = currentSlotText + " / " + maxSlotText;
    }
}
