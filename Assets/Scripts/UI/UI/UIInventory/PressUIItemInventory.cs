using UnityEngine.EventSystems;
public class PressUIItemInventory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemInventory uiItemInventory = GetComponent<UIItemInventory>();
        if (uiItemInventory == null) return;
        uiItemInventory.PressUIItemInventory();
    }
}
