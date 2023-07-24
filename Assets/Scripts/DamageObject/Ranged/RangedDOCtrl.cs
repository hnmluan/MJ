using UnityEngine;

public class RangedDOCtrl : InitMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected Despawn despawnDO;
    public Despawn DespawnDO { get => despawnDO; }

    [SerializeField] protected DamageObjectSO damageObjectSO;
    public DamageObjectSO DamageObjectSO => damageObjectSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadDespawnDO();
        this.LoadDamageObjectSO();
    }

    protected virtual void LoadDamageObjectSO()
    {
        if (this.damageObjectSO != null) return;
        string resPath = "DamageObject/Ranged/" + transform.name;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadDamageObjectSO " + resPath, gameObject);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadDespawnDO()
    {
        if (this.despawnDO != null) return;
        this.despawnDO = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawnDO", gameObject);
    }
}
