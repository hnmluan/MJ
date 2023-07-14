using UnityEngine;

public class Sunny : InitMonoBehaviour
{
    private static Sunny instance;
    public static Sunny Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (Sunny.instance != null) Debug.LogError("Only 1 Sunny allow to exist");
        Sunny.instance = this;
    }

    public void HandleUpdate()
    {

    }
}
