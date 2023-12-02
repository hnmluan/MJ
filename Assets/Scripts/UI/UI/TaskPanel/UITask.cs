using UnityEngine;

public class UITask : UIBase
{
    private static UITask instance;
    public static UITask Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UITask.instance != null) Debug.LogError("Only 1 UITask allow to exist");
        UITask.instance = this;
    }
}
