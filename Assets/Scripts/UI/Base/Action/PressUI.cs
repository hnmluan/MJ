using UnityEngine.EventSystems;

public abstract class PressUI : InitMonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public virtual void OnPointerClick(PointerEventData eventData) { }

    public virtual void OnPointerEnter(PointerEventData eventData) { }

    public virtual void OnPointerExit(PointerEventData eventData) { }
}
