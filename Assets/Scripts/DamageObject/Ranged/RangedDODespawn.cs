using UnityEngine;

public class RangedDODespawn : DespawnByTime
{

    [SerializeField] protected RangedDOCtrl rangedDOCtrl;
    public RangedDOCtrl RangedDOCtrl { get => rangedDOCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRangedDOCtrl();
    }

    protected virtual void LoadRangedDOCtrl()
    {
        if (this.rangedDOCtrl != null) return;
        this.rangedDOCtrl = transform.parent.GetComponent<RangedDOCtrl>();
        Debug.Log(transform.name + ": LoadRangedDOCtrl", gameObject);
    }

    protected override void ResetValue() => despawnTime = rangedDOCtrl.DamageObjectSO.range / rangedDOCtrl.DamageObjectSO.speed;

    public override void DespawnObject() => DamageObjectSpawner.Instance.Despawn(transform.parent);
}
