using UnityEngine;

public abstract class RangedDOAbstract : InitMonoBehaviour
{
    [Header("Projectile Abtract")]
    [SerializeField] protected RangedDOCtrl doCtrl;
    public RangedDOCtrl DOCtrl { get => doCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.doCtrl != null) return;
        this.doCtrl = transform.parent.GetComponent<RangedDOCtrl>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
