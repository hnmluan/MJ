using UnityEngine;

public class ProjectileDamageSender : DamageSender
{
    [SerializeField] protected ProjectileCtrl projectileCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadProjectileCtrl();
    }

    protected virtual void LoadProjectileCtrl()
    {
        if (this.projectileCtrl != null) return;
        this.projectileCtrl = transform.parent.GetComponent<ProjectileCtrl>();
        Debug.Log(transform.name + ": LoadProjectileCtrl", gameObject);
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyProjectile();
    }

    protected virtual void DestroyProjectile()
    {
        this.projectileCtrl.ProjectileDespawn.DespawnObject();
    }
}
