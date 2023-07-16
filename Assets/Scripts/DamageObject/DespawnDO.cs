public class DespawnDO : DespawnByTime
{
    public override void DespawnObject()
    {
        DOSpawner.Instance.Despawn(transform.parent);
    }
}
