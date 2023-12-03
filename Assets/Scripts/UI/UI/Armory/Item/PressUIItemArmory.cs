using UnityEngine.EventSystems;
public class PressUIItemArmory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemArmory uiWeapon = GetComponent<UIItemArmory>();
        UIArmory.Instance.UnfocusAll();
        uiWeapon.FocusItem();
        ItemArmory weapon = uiWeapon.Weapon;
        if (weapon == null) return;
        UIArmoryDetail.Instance.SetDetail(weapon);
    }
}
