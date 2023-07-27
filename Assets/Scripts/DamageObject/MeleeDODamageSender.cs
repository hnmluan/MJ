using UnityEngine;

public class MeleeDODamageSender : DODamageSender
{
    protected virtual void OnTriggerEnter(Collider other) => this.damageObjectCtrl.DamageObjectDamageSender.Send(other.transform);
}
