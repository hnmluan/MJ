using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class TxtInvDescDetail : BaseText
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
            GetComponent<LocalizedText>().LocalizationKey = "Item.Description";
            GetComponent<LocalizedText>().Localize();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    protected override void OnDisable()
    {
        GetComponent<LocalizedText>().LocalizationKey = "empty";
        GetComponent<LocalizedText>().Localize();
    }
}
