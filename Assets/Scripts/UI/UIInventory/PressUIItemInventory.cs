using UnityEngine.EventSystems;
public class PressUIItemInventory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ItemInventory itemInventory = this.GetComponent<UIItemInventory>().ItemInventory;
        if (itemInventory == null) return;
        UIInventoryIn4.Instance.ShowIn4(itemInventory);
    }
}
