using UnityEngine;

public class DamageSender : InitMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    [SerializeField] public bool isDameFromPlayer;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        if (damageReceiver.transform.parent.CompareTag("Player") && isDameFromPlayer) return;
        if (damageReceiver.transform.parent.CompareTag("Enemy") && !isDameFromPlayer) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver) => damageReceiver.Deduct(this.damage);

    protected override void OnEnable() => isDameFromPlayer = false;
}