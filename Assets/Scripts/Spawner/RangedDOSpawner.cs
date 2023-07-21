using UnityEngine;

public class RangedDOSpawner : Spawner
{
    private static RangedDOSpawner instance;
    public static RangedDOSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (RangedDOSpawner.instance != null) Debug.LogError("Only 1 ProjectileSpawner allow to exist");
        RangedDOSpawner.instance = this;
    }
}
