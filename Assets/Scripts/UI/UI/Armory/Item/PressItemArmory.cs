using UnityEngine.EventSystems;
public class PressItemArmory : PressUI
{
    public override void OnPointerClick(PointerEventData eventData) => UIArmory.Instance.SetCurrentItem(GetComponent<UIItemArmory>().Weapon);
}
