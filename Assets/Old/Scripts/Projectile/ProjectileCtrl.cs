using UnityEngine;

public class ProjectileCtrl : InitMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected ProjectileDespawn projectileDespawn;
    public ProjectileDespawn ProjectileDespawn { get => projectileDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadProjectileDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadProjectileDespawn()
    {
        if (this.projectileDespawn != null) return;
        this.projectileDespawn = transform.GetComponentInChildren<ProjectileDespawn>();
        Debug.Log(transform.name + ": LoadProjectileDespawn", gameObject);
    }

}
