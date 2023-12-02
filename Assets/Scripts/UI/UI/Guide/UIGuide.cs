using UnityEngine;

public class UIGuide : UIBase
{
    private static UIGuide instance;
    public static UIGuide Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIGuide.instance != null) Debug.LogError("Only 1 UIGuide allow to exist");
        UIGuide.instance = this;
    }
}