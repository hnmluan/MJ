using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class DictionaryInf4TypeText : BaseText
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

            GetComponent<LocalizedText>().LocalizationKey = "Item.Type." + UIDictionaryIn4.Instance.ItemDictionary.itemProfile.itemType.ToString().Replace(" ", "");
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
