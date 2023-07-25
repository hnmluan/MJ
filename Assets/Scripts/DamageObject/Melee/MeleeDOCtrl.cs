using UnityEngine;

public class MeleeDOCtrl : InitMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected MeleeDODespawn despawnDO;
    public MeleeDODespawn DespawnDO { get => despawnDO; }

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
        string resPath = "DamageObject/Melee/" + transform.name;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadRangedDOSO " + resPath, gameObject);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadRangedDODamageSender", gameObject);
    }

    protected virtual void LoadDespawnDO()
    {
        if (this.despawnDO != null) return;
        this.despawnDO = transform.GetComponentInChildren<MeleeDODespawn>();
        Debug.Log(transform.name + ": LoadRangedDODespawn", gameObject);
    }
}
