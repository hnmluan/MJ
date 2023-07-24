using UnityEngine;

public class DamageObjectSpawner : Spawner
{
    private static DamageObjectSpawner instance;
    public static DamageObjectSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (DamageObjectSpawner.instance != null) Debug.LogError("Only 1 DamageObjectSpawner allow to exist");
        DamageObjectSpawner.instance = this;
    }
}
