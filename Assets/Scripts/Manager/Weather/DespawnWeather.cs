public class DespawnWeather : DespawnByTime
{
    public override void DespawnObject()
    {
        WeatherSpawner.Instance.Despawn(transform.parent);
    }
}
