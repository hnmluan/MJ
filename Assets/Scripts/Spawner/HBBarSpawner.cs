using UnityEngine;

public class HBBarSpawner : Spawner
{
    private static HBBarSpawner instance;
    public static HBBarSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (HBBarSpawner.instance != null) Debug.Log("Only 1 HBBarSpawner allow to exist");
        HBBarSpawner.instance = this;
    }
}
