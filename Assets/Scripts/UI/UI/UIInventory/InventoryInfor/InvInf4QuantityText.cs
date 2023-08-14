

using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class InvInf4QuantityText : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        try
        {
            if (UIInvIn4.Instance.ItemInventory == null)
            {
                text.text = "0";
                return;
            }
            text.text = UIInvIn4.Instance.ItemInventory.itemCount.ToString();
        }
        catch (System.Exception)
        {
            text.text = "0";
        }

    }
}
