using UnityEngine;

public class UICtrl : Singleton<UICtrl>
{
    [SerializeField] private bool isOpen = true;
    public bool IsOpen { get => isOpen; set => isOpen = value; }
}
