using Assets.SimpleLocalization;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectOption : MonoBehaviour
{
    [SerializeField] private Button button;

    [SerializeField] private LocalizedText text;

    public event Action ClickAction;

    private void Awake() => button.onClick.AddListener(CallbackAction);

    private void OnDestroy() => button.onClick.RemoveListener(CallbackAction);

    public void ShowOption(string localizationKey, Action action)
    {
        gameObject.SetActive(true);
        text.LocalizationKey = localizationKey;
        ClickAction = action;
    }

    public void CallbackAction()
    {
        ClickAction?.Invoke();
        ClickAction = null;
    }
}
