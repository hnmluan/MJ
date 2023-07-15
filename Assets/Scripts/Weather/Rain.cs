using System.Collections.Generic;
using UnityEngine;


public class Rain : Weather
{
    private static Rain instance;
    public static Rain Instance { get => instance; }

    public int numberOfRaindrops = 20;

    public int numberOfRainOnFloor = 20;

    public float spawnInterval = 0.5f;

    private float timer = 0f;

    public List<string> rainNames;

    public List<string> rainOnFloorNames;

    protected override void Awake()
    {
        base.Awake();
        if (Rain.instance != null) Debug.LogError("Only 1 Rain allow to exist");
        Rain.instance = this;
    }

    public override void HandleUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnWeatherElements(rainNames, numberOfRaindrops);

            SpawnWeatherElements(rainOnFloorNames, numberOfRainOnFloor);

            timer = 0f;
        }
    }
}

