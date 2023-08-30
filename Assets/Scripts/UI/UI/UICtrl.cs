using System;
using UnityEngine;

public class UICtrl : Singleton<UICtrl>
{
    [SerializeField] private bool isOpen = true;
    public bool IsOpen { get => isOpen; set => isOpen = value; }

    public event Action OnShowSetting, OnHideSetting;

    public void OpenSetting() => this.OnShowSetting?.Invoke();
    public void CloseSetting() => this.OnHideSetting?.Invoke();
}
