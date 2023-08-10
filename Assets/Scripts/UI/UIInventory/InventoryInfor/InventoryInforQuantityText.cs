

using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class InventoryInforQuantityText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        if (UIInventoryIn4.Instance.ItemInventory == null)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            return;
        }
        GetComponent<LocalizedText>().LocalizationKey = "Item." + UIInventoryIn4.Instance.ItemInventory.itemProfile.itemName.Replace(" ", "");
        GetComponent<LocalizedText>().Localize();
    }
}
