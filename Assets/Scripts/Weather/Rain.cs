using System.Collections.Generic;
using UnityEngine;


public class Rain : InitMonoBehaviour
{
    private static Rain instance;
    public static Rain Instance { get => instance; }

    public int numberOfRaindrops = 20; // Số lượng giọt mưa cần spawn

    public int numberOfRainOnFloor = 20; // Số lượng giọt mưa cần spawn

    public float spawnInterval = 0.5f; // Khoảng thời gian giữa các lần spawn

    private float timer = 0f;

    public List<string> rainNames;

    public List<string> rainOnFloorNames;

    protected override void Awake()
    {
        base.Awake();
        if (Rain.instance != null) Debug.LogError("Only 1 Rain allow to exist");
        Rain.instance = this;
    }

    public void HandleUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            for (int i = 0; i < numberOfRaindrops; i++)
            {
                Transform rainDrop = WeatherSpawner.Instance.Spawn(rainNames[Random.Range(0, rainNames.Count - 1)], GetRandomPointInGame(), Quaternion.identity);
                if (rainDrop == null) return;
                rainDrop.gameObject.SetActive(true);
            }

            for (int i = 0; i < numberOfRainOnFloor; i++)
            {

                Transform rainOnFloor = WeatherSpawner.Instance.Spawn(rainOnFloorNames[Random.Range(0, rainOnFloorNames.Count - 1)], GetRandomPointInGame(), Quaternion.identity);
                if (rainOnFloor == null) return;
                rainOnFloor.gameObject.SetActive(true);
            }

            timer = 0f;
        }
    }

    public Vector3 GetRandomPointInGame()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector3 randomPosition = new Vector3(Random.Range(0, screenWidth * 2), Random.Range(0, screenHeight * 2), 0);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);
        worldPosition.z = 0;

        return worldPosition;
    }
}

