using UnityEngine;

public class UISetting : BaseUI
{
    [Header("UI Setting")]
    private static UISetting instance;
    public static UISetting Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UISetting.instance != null) Debug.LogError("Only 1 UISetting allow to exist");
        UISetting.instance = this;
    }
}