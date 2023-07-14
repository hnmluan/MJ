using UnityEngine;

public class WeatherSpawner : Spawner
{
    private static WeatherSpawner instance;
    public static WeatherSpawner Instance { get => instance; }

    public static string enemyOne = "RainDrop";

    public static string enemyTwo = "RainOnFloor";

    public static string enemyThree = "Leaf";

    public static string enemyFour = "Cloud";

    protected override void Awake()
    {
        base.Awake();
        if (WeatherSpawner.instance != null) Debug.LogError("Only 1 WeatherSpawner allow to exist");
        WeatherSpawner.instance = this;
    }
}
