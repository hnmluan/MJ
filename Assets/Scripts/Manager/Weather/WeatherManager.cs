using UnityEngine;

public enum WeatherState { Rain, Sunny }

public class WeatherManager : Singleton<WeatherManager>
{
    private static WeatherManager instance;
    public static WeatherManager Instance { get => instance; }

    [SerializeField] protected WeatherState state = WeatherState.Rain;
    public WeatherState State { get => state; }

    protected override void Awake()
    {
        base.Awake();
        if (WeatherManager.instance != null) Debug.Log("Only 1 WeatherManager allow to exist");
        WeatherManager.instance = this;
    }

    private void Update()
    {
        if (state == WeatherState.Rain) Rain.Instance.HandleUpdate();
        else if (state == WeatherState.Sunny) Sunny.Instance.HandleUpdate();

    }

}

