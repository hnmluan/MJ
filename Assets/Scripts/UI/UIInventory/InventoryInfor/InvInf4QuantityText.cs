

using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class InvInf4QuantityText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        if (UIInvIn4.Instance.ItemInventory == null)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            return;
        }
        GetComponent<LocalizedText>().LocalizationKey = "Item." + UIInvIn4.Instance.ItemInventory.itemProfile.itemName.Replace(" ", "");
        GetComponent<LocalizedText>().Localize();
    }
}
