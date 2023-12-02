using UnityEngine;

public class UISetting : UIBase
{
    private static UISetting instance;
    public static UISetting Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UISetting.instance != null) Debug.LogError("Only 1 UISetting allow to exist");
        UISetting.instance = this;
    }
}