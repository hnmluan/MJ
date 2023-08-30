using UnityEngine;

public class WeatherSpawner : Spawner
{
    private static WeatherSpawner instance;
    public static WeatherSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (WeatherSpawner.instance != null) Debug.Log("Only 1 WeatherSpawner allow to exist");
        WeatherSpawner.instance = this;
    }
}
