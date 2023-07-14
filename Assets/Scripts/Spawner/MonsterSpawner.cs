using UnityEngine;

public class MonsterSpawner : Spawner
{
    private static MonsterSpawner instance;
    public static MonsterSpawner Instance { get => instance; }

    public static string enemyOne = "Slime";

    public static string enemyTwo = "Mushroom";

    protected override void Awake()
    {
        base.Awake();
        if (MonsterSpawner.instance != null) Debug.LogError("Only 1 MonsterSpawner allow to exist");
        MonsterSpawner.instance = this;
    }
}
