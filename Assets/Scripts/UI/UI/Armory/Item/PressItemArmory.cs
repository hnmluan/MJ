using UnityEngine.EventSystems;
public class PressItemArmory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemArmory uiWeapon = GetComponent<UIItemArmory>();
        UIArmory.Instance.UnfocusAll();
        uiWeapon.FocusItem();
        ItemArmory weapon = uiWeapon.Weapon;
        if (weapon == null) return;
        UIArmory.Instance.UIArmoryDetail.Show(weapon);
    }
}
