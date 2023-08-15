public class TxtInventorySlot : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateSlot();

    protected virtual void UpdateSlot()
    {
        int currentSlotText = Inventory.Instance.GetCurrentSlot();
        int maxSlotText = Inventory.Instance.MaxSlot;
        this.text.text = currentSlotText + " / " + maxSlotText;
    }
}
