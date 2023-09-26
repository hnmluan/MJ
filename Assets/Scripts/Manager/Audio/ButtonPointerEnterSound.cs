using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPointerEnterSound : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData) => AudioManager.Instance.Play("ButtonPointerEnter");
}
