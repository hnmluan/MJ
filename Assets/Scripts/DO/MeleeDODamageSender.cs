using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class MeleeDODamageSender : DamageSender
{
    [SerializeField] protected RangedDOCtrl doCtrl;
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDOCtrl();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;   
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void LoadDOCtrl()
    {
        if (this.doCtrl != null) return;
        this.doCtrl = transform.parent.GetComponent<RangedDOCtrl>();
        Debug.Log(transform.name + ": LoadDOCtrl", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other) => this.doCtrl.DamageSender.Send(other.transform);
}
