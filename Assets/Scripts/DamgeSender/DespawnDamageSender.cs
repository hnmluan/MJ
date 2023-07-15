public class DespawnDamageSender : DespawnByTime
{
    public override void DespawnObject()
    {
        DamgeSenderSpawner.Instance.Despawn(transform.parent);
    }
}
