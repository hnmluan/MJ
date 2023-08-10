using Assets.SimpleLocalization;

public class InvIn4DescriptionText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        if (UIInvIn4.Instance.ItemInventory == null)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            return;
        }
        GetComponent<LocalizedText>().LocalizationKey = "Item.Description";
        GetComponent<LocalizedText>().Localize();
    }
}
