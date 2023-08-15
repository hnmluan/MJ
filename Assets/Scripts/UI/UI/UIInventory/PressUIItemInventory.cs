using UnityEngine.EventSystems;
public class PressUIItemInventory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ItemInventory itemInventory = this.GetComponent<UIItemInventory>().ItemInventory;
        if (itemInventory == null) return;
        UIInvDetail.Instance.SetUIInvDetail(itemInventory);
    }
}
