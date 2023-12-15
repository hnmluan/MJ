using System.Collections.Generic;
using UnityEngine;

public abstract class Weather : InitMonoBehaviour
{
    public abstract void HandleUpdate();

    protected void SpawnWeatherElements(List<string> weatherElemnetName, int numberOfWeatherElement)
    {
        for (int i = 0; i < numberOfWeatherElement; i++)
        {
            Transform weatherElemnet = WeatherSpawner.Instance.Spawn(weatherElemnetName[Random.Range(0, weatherElemnetName.Count - 1)], GetRandomPoint(), Quaternion.identity);
            if (weatherElemnet == null) return;
            weatherElemnet.gameObject.SetActive(true);
        }
    }

    protected void SpawnWeatherElement(string weatherElemnetName, int numberOfWeatherElement)
    {
        for (int i = 0; i < numberOfWeatherElement; i++)
        {
            Transform weatherElemnet = WeatherSpawner.Instance.Spawn(weatherElemnetName, GetRandomPoint(), Quaternion.identity);
            if (weatherElemnet == null) return;
            weatherElemnet.gameObject.SetActive(true);
        }
    }

    private Vector3 GetRandomPoint()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector3 randomPosition = new Vector3(Random.Range(-screenWidth * 2, screenWidth * 2), Random.Range(-screenHeight * 2, screenHeight * 2), 0);

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);
        worldPosition.z = 0;

        return worldPosition;
    }
}
