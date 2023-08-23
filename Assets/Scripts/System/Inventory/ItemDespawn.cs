public class ItemDespawn : DespawnByTime
{
    public override void DespawnObject() => ItemDropSpawner.Instance.Despawn(transform.parent);

    protected override void ResetValue() => this.despawnTime = 5f;
}