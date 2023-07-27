using UnityEngine;

public class RangedDODamageSender : DODamageSender
{
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyDO();
    }

    protected virtual void DestroyDO() => this.damageObjectCtrl.DamageObjectDespawn.DespawnObject();

    protected virtual void OnTriggerEnter(Collider other) => this.damageObjectCtrl.D0DamageSender.Send(other.transform);
}
