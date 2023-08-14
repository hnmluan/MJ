

using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class DictionaryInf4QuantityText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        try
        {
            if (UIDictionaryIn4.Instance.ItemDictionary == null)
            {
                text.text = "0";
                return;
            }
            text.text = UIDictionaryIn4.Instance.ItemDictionary.itemCount.ToString();
        }
        catch (System.Exception)
        {
            text.text = "0";
        }

    }
}
