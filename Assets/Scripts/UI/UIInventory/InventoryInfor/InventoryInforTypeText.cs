using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class InventoryInforTypeText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        if (UIInventoryIn4.Instance.ItemInventory == null)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            return;
        }


        GetComponent<LocalizedText>().LocalizationKey = "Item.Type." + UIInventoryIn4.Instance.ItemInventory.itemProfile.itemType.ToString().Replace(" ", "");
        GetComponent<LocalizedText>().Localize();
    }
}
