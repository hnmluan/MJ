using UnityEngine;

public abstract class DOCtrl : InitMonoBehaviour
{
    [SerializeField] protected SpriteRenderer doSR;
    public SpriteRenderer DOSR => doSR;

    [SerializeField] protected DamageSender doDamageSender;
    public DamageSender D0DamageSender { get => doDamageSender; }

    [SerializeField] protected DespawnByTime damageObjectDespawn;
    public DespawnByTime DamageObjectDespawn { get => damageObjectDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectSR();
        this.LoadDamageObjectDamageSender();
        this.LoadDamageObjectDespawn();
    }

    protected void LoadDamageObjectSR()
    {
        if (this.doSR != null) return;
        this.doSR = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadDamageObjectSR ", gameObject);
    }

    protected virtual void LoadDamageObjectDamageSender()
    {
        if (this.doDamageSender != null) return;
        this.doDamageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageObjectDamageSender", gameObject);
    }

    protected virtual void LoadDamageObjectDespawn()
    {
        if (this.damageObjectDespawn != null) return;
        this.damageObjectDespawn = transform.GetComponentInChildren<DespawnByTime>();
        Debug.Log(transform.name + ": LoadDamageObjectDespawn", gameObject);
    }
}
