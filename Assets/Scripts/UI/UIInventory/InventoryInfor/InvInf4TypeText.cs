using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class InvInf4TypeText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        if (UIInvIn4.Instance.ItemInventory == null)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            return;
        }


        GetComponent<LocalizedText>().LocalizationKey = "Item.Type." + UIInvIn4.Instance.ItemInventory.itemProfile.itemType.ToString().Replace(" ", "");
        GetComponent<LocalizedText>().Localize();
    }
}
