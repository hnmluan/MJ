using System;
using UnityEngine;

public class UICtrl : InitMonoBehaviour
{
    private static UICtrl instance;
    public static UICtrl Instance { get => instance; }

    [SerializeField] private bool isOpen = true;
    public bool IsOpen { get => isOpen; set => isOpen = value; }

    public event Action OnShowSetting, OnHideSetting;

    protected override void Awake()
    {
        base.Awake();

        if (UICtrl.instance != null) Debug.LogError("Only 1 UICtrl allow to exist");

        UICtrl.instance = this;
    }

    public void OpenSetting() => this.OnShowSetting?.Invoke();
    public void CloseSetting() => this.OnHideSetting?.Invoke();
}
