using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class DODamageSender : DamageSender
{
    [SerializeField] protected DOCtrl damageObjectCtrl;

    [SerializeField] protected SphereCollider sphereCollider;

    [SerializeField] protected Rigidbody rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectCtrl();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        this.rb.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void LoadDamageObjectCtrl()
    {
        if (this.damageObjectCtrl != null) return;
        this.damageObjectCtrl = transform.parent.GetComponent<DOCtrl>();
        Debug.Log(transform.name + ": LoadDamageObjectCtrl", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        if (damageObjectCtrl.DOSO.damageObjectType == DamageObjectType.Melee) return;
        this.DestroyDO();
    }

    protected virtual void DestroyDO() => this.damageObjectCtrl.DamageObjectDespawn.DespawnObject();

    protected virtual void OnTriggerEnter(Collider other) => this.damageObjectCtrl.DODamageSender.Send(other.transform);
}
