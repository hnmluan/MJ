using UnityEngine;

public class UIReward : UIBase
{
    private static UIReward instance;

    public static UIReward Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIReward.instance != null) Debug.LogError("Only 1 UIReward allow to exist");
        UIReward.instance = this;
    }
}
