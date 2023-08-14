

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
            if (UIInventoryDetail.Instance.ItemInventory == null)
            {
                text.text = "0";
                return;
            }
            text.text = UIInventoryDetail.Instance.ItemInventory.itemCount.ToString();
        }
        catch (System.Exception)
        {
            text.text = "0";
        }

    }
}
