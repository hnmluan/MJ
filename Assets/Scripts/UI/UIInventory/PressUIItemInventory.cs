using UnityEngine.EventSystems;
public class PressUIItemInventory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ItemInventory itemInventory = this.GetComponent<UIItemInventory>().ItemInventory;
        if (itemInventory == null) return;
        UIInvIn4.Instance.ResetUIInfor(itemInventory);
    }
}
