public class MeleeDODespawn : DespawnByTime
{
    public override void DespawnObject() => MeleeDOSpawner.Instance.Despawn(transform.parent);
}
