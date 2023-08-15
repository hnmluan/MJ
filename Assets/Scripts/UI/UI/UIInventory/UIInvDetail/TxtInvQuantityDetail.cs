

using Assets.SimpleLocalization;
using UnityEngine;

[RequireComponent(typeof(LocalizedText))]
public class TxtInvQuantityDetail : BaseText
{
    protected virtual void FixedUpdate() => this.UpdateText();

    protected virtual void UpdateText()
    {
        try
        {
            if (UIInvDetail.Instance.ItemInventory == null)
            {
                text.text = "0";
                return;
            }
            text.text = UIInvDetail.Instance.ItemInventory.itemCount.ToString();
        }
        catch (System.Exception)
        {
            text.text = "0";
        }

    }
}
