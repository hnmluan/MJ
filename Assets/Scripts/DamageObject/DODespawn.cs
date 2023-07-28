public class DODespawn : DespawnByTime
{
    public override void DespawnObject() => DOSpawner.Instance.Despawn(transform.parent);
}
