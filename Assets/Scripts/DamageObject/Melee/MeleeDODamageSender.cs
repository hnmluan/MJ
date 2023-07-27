using UnityEngine;

public class MeleeDODamageSender : DODamageSender
{
    protected virtual void OnTriggerEnter(Collider other) => this.damageObjectCtrl.D0DamageSender.Send(other.transform);
}
