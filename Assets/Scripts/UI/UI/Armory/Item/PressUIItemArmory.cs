using UnityEngine.EventSystems;
public class PressUIItemArmory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemArmory uiWeapon = GetComponent<UIItemArmory>();
        ItemArmory weapon = uiWeapon.Weapon;
        if (weapon == null) return;
        UIArmoryDetail.Instance.SetEmptyUIArmoryDetail();
        UIArmoryDetail.Instance.SetUIArmoryDetail(weapon);
    }
}
