using UnityEngine;

public class RangedDOCtrl : DOCtrl
{
    [SerializeField] protected DamageObjectSO rangedDOSO;
    public DamageObjectSO RangedDOSO => rangedDOSO;

    [SerializeField] protected RangedDOMovement rangedDamageObjectMovement;
    public RangedDOMovement RangedDamageObjectMovement => rangedDamageObjectMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRangedDOSO();
        this.LoadRangedDOMovement();
    }

    protected override void ResetValue()
    {
        if (this.rangedDOSO == null) return;
        doSR.sprite = rangedDOSO.spriteInAttack;
        rangedDamageObjectMovement.movespeed = rangedDOSO.speed;
        doDamageSender.damage = rangedDOSO.damage;
        damageObjectDespawn.despawnTime = rangedDOSO.range / rangedDOSO.speed;
    }

    protected virtual void LoadRangedDOSO()
    {
        if (this.rangedDOSO != null) return;
        string resPath = "DamageObject/Ranged/" + transform.name;
        this.rangedDOSO = Resources.Load<DamageObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadDamageObjectSO " + resPath, gameObject);
    }

    protected void LoadRangedDOMovement()
    {
        if (this.rangedDamageObjectMovement != null) return;
        this.rangedDamageObjectMovement = transform.GetComponentInChildren<RangedDOMovement>();
        Debug.Log(transform.name + ": LoadRangedDOMovement ", gameObject);
    }
}
