using UnityEngine.EventSystems;
public class PressUIItemArmory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        UIItemArmory uiWeapon = GetComponent<UIItemArmory>();
        Weapon Weapon = uiWeapon.Weapon;
        if (Weapon == null) return;
        UIArmoryDetail.Instance.SetEmptyUIArmoryDetail();
        UIArmoryDetail.Instance.SetUIArmoryDetail(Weapon);
    }
}
