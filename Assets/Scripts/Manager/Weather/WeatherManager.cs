using UnityEngine;

public enum WeatherState { Rain, Sunny }

public class WeatherManager : Singleton<WeatherManager>
{
    [SerializeField] protected WeatherState state = WeatherState.Rain;
    public WeatherState State { get => state; }

    private void Update()
    {
        if (state == WeatherState.Rain) Rain.Instance.HandleUpdate();
        if (state == WeatherState.Sunny) Sunny.Instance.HandleUpdate();
    }
}

