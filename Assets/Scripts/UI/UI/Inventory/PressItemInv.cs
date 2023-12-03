using UnityEngine.EventSystems;
public class PressItemInv : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemInventory uiItemInventory = GetComponent<UIItemInventory>();
        if (uiItemInventory == null) return;
        uiItemInventory.Press();
    }
}
