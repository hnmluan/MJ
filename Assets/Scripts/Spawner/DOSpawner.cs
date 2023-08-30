using UnityEngine;

public class DOSpawner : Spawner
{
    private static DOSpawner instance;
    public static DOSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (DOSpawner.instance != null) Debug.Log("Only 1 DOSpawner allow to exist");
        DOSpawner.instance = this;
    }
}
