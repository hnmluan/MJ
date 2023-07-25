public class RangedDODespawn : DespawnByTime
{
    public override void DespawnObject() => DamageObjectSpawner.Instance.Despawn(transform.parent);
}
