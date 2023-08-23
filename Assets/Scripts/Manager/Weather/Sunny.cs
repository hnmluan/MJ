using System.Collections.Generic;
using UnityEngine;

public class Sunny : Weather
{
    private static Sunny instance;
    public static Sunny Instance { get => instance; }

    public int numberOfClound = 20;

    public int numberOfLeaf = 20;

    public float spawnInterval = 0.5f;

    private float timer = 0f;

    public List<string> cloundNames;

    public List<string> leafNames;

    protected override void Awake()
    {
        base.Awake();
        if (Sunny.instance != null) Debug.LogError("Only 1 Sunny allow to exist");
        Sunny.instance = this;
    }

    public override void HandleUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnWeatherElements(cloundNames, numberOfClound);

            SpawnWeatherElements(leafNames, numberOfLeaf);

            timer = 0f;
        }
    }
}
