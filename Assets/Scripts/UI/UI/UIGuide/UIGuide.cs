using UnityEngine;

public class UIGuide : BaseUI
{
    [Header("UI Guide")]
    private static UIGuide instance;
    public static UIGuide Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIGuide.instance != null) Debug.Log("Only 1 UIGuide allow to exist");
        UIGuide.instance = this;
    }
}