using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class TxtInvTypeDetail : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        try
        {
            if (UIInvDetail.Instance.ItemInventory == null)
            {
                GetComponent<LocalizedText>().LocalizationKey = "empty";
                GetComponent<LocalizedText>().Localize();
                return;
            }

            GetComponent<LocalizedText>().LocalizationKey = "Item.Type." + UIInvDetail.Instance.ItemInventory.itemProfile.itemType.ToString().Replace(" ", "");
            GetComponent<LocalizedText>().Localize();
        }
        catch (System.Exception)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            GetComponent<LocalizedText>().Localize();
        }

    }

    protected override void OnDisable()
    {
        GetComponent<LocalizedText>().LocalizationKey = "empty";
        GetComponent<LocalizedText>().Localize();
    }
}
