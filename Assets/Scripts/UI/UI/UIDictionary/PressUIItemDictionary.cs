using UnityEngine;
using UnityEngine.EventSystems;
public class PressUIItemDictionary : PressUI
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        ScriptableObject objSO = this.GetComponent<UIItemDictionary>().ItemDictionary;
        if (objSO == null) return;
        Dictionary.Instance.SeenItemDictionary(objSO);
        UIDictionaryDetail.Instance.ShowDetailObj(objSO);
    }
}
