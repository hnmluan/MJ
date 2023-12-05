using UnityEngine.EventSystems;
public class PressItemInv : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemInventory item = GetComponent<UIItemInventory>();
        if (item == null) return;
        item.Press();
    }
}
