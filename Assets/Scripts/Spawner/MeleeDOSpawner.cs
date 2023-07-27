using UnityEngine;

public class MeleeDOSpawner : Spawner
{
    private static MeleeDOSpawner instance;
    public static MeleeDOSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (MeleeDOSpawner.instance != null) Debug.LogError("Only 1 MeleeDOSpawner allow to exist");
        MeleeDOSpawner.instance = this;
    }
}
