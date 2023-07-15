using UnityEngine;

public class DamgeSenderSpawner : Spawner
{
    private static DamgeSenderSpawner instance;
    public static DamgeSenderSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (DamgeSenderSpawner.instance != null) Debug.LogError("Only 1 ProjectileSpawner allow to exist");
        DamgeSenderSpawner.instance = this;
    }
}
