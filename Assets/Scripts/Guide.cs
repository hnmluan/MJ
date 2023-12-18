using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Guide : InitMonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<GameObject> guides;

    private int _currentGuide = 0;

    protected override void Start()
    {
        if (guides.Count == 0) Destroy(gameObject);
        guides[0].gameObject.SetActive(true);
    }

    protected override void Awake() => InputManager.Instance.gameObject.SetActive(false);

    private void OnDestroy() => InputManager.Instance.gameObject.SetActive(true);

    public void OnPointerClick(PointerEventData eventData) => MoveToMextGuide();

    private void MoveToMextGuide()
    {
        guides[_currentGuide++].gameObject.SetActive(false);
        if (_currentGuide >= guides.Count) Destroy(gameObject);
        else guides[_currentGuide].gameObject.SetActive(true);
    }
}
