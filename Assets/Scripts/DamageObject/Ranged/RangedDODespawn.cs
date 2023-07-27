public class RangedDODespawn : DespawnByTime
{
    public override void DespawnObject() => RangedDOSpawner.Instance.Despawn(transform.parent);
}
