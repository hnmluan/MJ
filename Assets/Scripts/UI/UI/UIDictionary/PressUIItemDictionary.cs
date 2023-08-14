using UnityEngine.EventSystems;
public class PressUIItemDictionary : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ItemDictionary itemDictionary = this.GetComponent<UIItemDictionary>().ItemDictionary;
        if (itemDictionary == null) return;
        UIDictionaryIn4.Instance.ResetUIInfor(itemDictionary);
    }
}
