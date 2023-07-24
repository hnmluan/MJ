public class DespawnDO : DespawnByTime
{
    public override void DespawnObject() => DamageObjectSpawner.Instance.Despawn(transform.parent);
}
