using UnityEngine.EventSystems;
public class PressUIItemInventory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemInventory uiItemInventory = GetComponent<UIItemInventory>();
        ItemInventory itemInventory = uiItemInventory.ItemInventory;
        if (itemInventory == null) return;
        UIInvDetail.Instance.SetUIInvDetail(itemInventory);
        UIInventory.Instance.CurrSlots = UIInventory.Instance.GetIndexSlot(itemInventory);
        //uiItemInventory.ShowItem(itemInventory);
        UIInventory.Instance.ShowItems();
    }
}
