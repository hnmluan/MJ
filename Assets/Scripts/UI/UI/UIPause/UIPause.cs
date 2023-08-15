using UnityEngine;

public class UIPause : BaseUI
{
    [Header("UI Pause")]
    private static UIPause instance;
    public static UIPause Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIPause.instance != null) Debug.LogError("Only 1 UIPause allow to exist");
        UIPause.instance = this;
    }
}