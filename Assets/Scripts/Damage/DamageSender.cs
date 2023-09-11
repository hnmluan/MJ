using UnityEngine;

public class DamageSender : InitMonoBehaviour
{
    [SerializeField] public int damage = 1;

    [SerializeField] public string tagParent;

    public void SetDamage(int damage) => this.damage = damage;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver) => damageReceiver.Deduct(this.damage);
}