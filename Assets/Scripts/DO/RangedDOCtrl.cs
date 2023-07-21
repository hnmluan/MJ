using UnityEngine;

public class RangedDOCtrl : InitMonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected DespawnDO despawnDO;
    public DespawnDO DespawnDO { get => despawnDO; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadDespawnDO();
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
        this.despawnDO = transform.GetComponentInChildren<DespawnDO>();
        Debug.Log(transform.name + ": LoadDespawnDO", gameObject);
    }

}
