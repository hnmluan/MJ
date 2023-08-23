using UnityEngine.EventSystems;
public class PressUIItemArmory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemArmory uiWeapon = GetComponent<UIItemArmory>();
        Weapon weapon = uiWeapon.Weapon;
        if (weapon == null) return;
        UIArmoryDetail.Instance.SetEmptyUIArmoryDetail();
        UIArmoryDetail.Instance.SetUIArmoryDetail(weapon);
        UIArmory.Instance.SetCurrentItemInventory(UIArmory.Instance.GetIndexItemInventory(weapon));
        UIArmory.Instance.KeepFocusInCurrentItemArmory();
    }
}
