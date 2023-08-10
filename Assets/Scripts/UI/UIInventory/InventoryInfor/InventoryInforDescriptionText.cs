using Assets.SimpleLocalization;

public class InventoryInforDescriptionText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        if (UIInventoryIn4.Instance.ItemInventory == null)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            return;
        }
        GetComponent<LocalizedText>().LocalizationKey = "Item.Description";
        GetComponent<LocalizedText>().Localize();
    }
}
