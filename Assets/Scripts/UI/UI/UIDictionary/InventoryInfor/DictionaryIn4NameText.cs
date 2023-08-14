using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class DictionaryIn4NameText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        try
        {
            if (UIDictionaryIn4.Instance.ItemDictionary == null)
            {
                GetComponent<LocalizedText>().LocalizationKey = "empty";
                GetComponent<LocalizedText>().Localize();
                return;
            }
            GetComponent<LocalizedText>().LocalizationKey = "Item." + UIDictionaryIn4.Instance.ItemDictionary.itemProfile.itemName.Replace(" ", "");
            GetComponent<LocalizedText>().Localize();
        }
        catch (System.Exception)
        {
            GetComponent<LocalizedText>().LocalizationKey = "empty";
            GetComponent<LocalizedText>().Localize();
        }
    }
}
