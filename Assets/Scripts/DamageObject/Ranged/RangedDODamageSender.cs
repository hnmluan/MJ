using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class RangedDODamageSender : DamageSender
{
    [SerializeField] protected RangedDOCtrl rangedDOCtrl;

    [SerializeField] protected SphereCollider sphereCollider;

    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRangedDOCtrl();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void LoadRangedDOCtrl()
    {
        if (this.rangedDOCtrl != null) return;
        this.rangedDOCtrl = transform.parent.GetComponent<RangedDOCtrl>();
        Debug.Log(transform.name + ": LoadRangedDOCtrl", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyDO();
    }

    protected virtual void DestroyDO() => this.rangedDOCtrl.DespawnDO.DespawnObject();

    protected virtual void OnTriggerEnter(Collider other) => this.rangedDOCtrl.DamageSender.Send(other.transform);
}
