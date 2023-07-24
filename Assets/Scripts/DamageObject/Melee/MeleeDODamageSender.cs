using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class MeleeDODamageSender : DamageSender
{
    [SerializeField] protected MeleeDOCtrl meleeDOCtrl;

    [SerializeField] protected BoxCollider boxCollider;

    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeleeDOCtrl();
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

    protected virtual void LoadMeleeDOCtrl()
    {
        if (this.meleeDOCtrl != null) return;
        this.meleeDOCtrl = transform.parent.GetComponent<MeleeDOCtrl>();
        Debug.Log(transform.name + ": LoadMeleeDOCtrl", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other) => this.meleeDOCtrl.DamageSender.Send(other.transform);
}
