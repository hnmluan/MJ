using UnityEngine;

public class UIPause : UIBase
{
    private static UIPause instance;
    public static UIPause Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIPause.instance != null) Debug.LogError("Only 1 UIPause allow to exist");
        UIPause.instance = this;
    }
}