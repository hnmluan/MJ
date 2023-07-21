public class DespawnDO : DespawnByTime
{
    public override void DespawnObject()
    {
        RangedDOSpawner.Instance.Despawn(transform.parent);
    }
}
