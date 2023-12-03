using UnityEngine;
using UnityEngine.EventSystems;
public class PressItemDict : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ScriptableObject objSO = this.GetComponent<UIItemDictionary>().ItemDictionary;
        if (objSO == null) return;
        Dictionary.Instance.SeenItem(objSO);
        UIDictionary.Instance.DictionaryDetail.ShowDetailObj(objSO);
    }
}
