using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.Log("Only 1 FXSpawner allow to exist");
        FXSpawner.instance = this;
    }
}
