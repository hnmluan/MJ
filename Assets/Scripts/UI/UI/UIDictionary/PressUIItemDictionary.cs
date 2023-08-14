using UnityEngine.EventSystems;
public class PressUIItemDictionary : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        EnemyProfileSO itemDictionary = this.GetComponent<UIItemDictionary>().ItemDictionary as EnemyProfileSO;
        if (itemDictionary == null) return;
        UIDictionaryIn4.Instance.ResetUIInfor(itemDictionary);
    }
}
