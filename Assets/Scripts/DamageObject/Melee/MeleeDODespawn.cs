public class MeleeDODespawn : DespawnByTime
{
    public override void DespawnObject() => DamageObjectSpawner.Instance.Despawn(transform.parent);
}
