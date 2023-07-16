using UnityEngine;

public abstract class DOAbstract : InitMonoBehaviour
{
    [Header("Projectile Abtract")]
    [SerializeField] protected DOCtrl doCtrl;
    public DOCtrl DOCtrl { get => doCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.doCtrl != null) return;
        this.doCtrl = transform.parent.GetComponent<DOCtrl>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
