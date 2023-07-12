using UnityEngine;

public abstract class ProjectileAbstract : InitMonoBehaviour
{
    [Header("Projectile Abtract")]
    [SerializeField] protected ProjectileCtrl projectileCtrl;
    public ProjectileCtrl ProjectileCtrl { get => projectileCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.projectileCtrl != null) return;
        this.projectileCtrl = transform.parent.GetComponent<ProjectileCtrl>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
