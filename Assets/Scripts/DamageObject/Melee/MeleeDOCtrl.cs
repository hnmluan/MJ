using UnityEngine;

public class MeleeDOCtrl : DOCtrl
{
    [SerializeField] protected DamageObjectSO meleeDOSO;
    public DamageObjectSO MeleeDOSO => meleeDOSO;

    [SerializeField] protected MeleeDOMovement meleeDamageObjectMovement;
    public MeleeDOMovement MeleeDamageObjectMovement => meleeDamageObjectMovement;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeleeDOSO();
        this.LoadMeleeDOMovement();
    }

    protected override void ResetValue()
    {
        if (this.meleeDOSO == null) return;
        doSR.sprite = meleeDOSO.spriteInAttack;
        meleeDamageObjectMovement.timeMove = meleeDOSO.attackTime;
        doDamageSender.damage = meleeDOSO.damage;
        meleeDamageObjectMovement.timeMove = meleeDOSO.attackTime;
        DamageObjectDespawn.despawnTime = meleeDOSO.attackTime;
    }

    protected void LoadMeleeDOSO()
    {
        if (this.meleeDOSO != null) return;
        string resPath = "DamageObject/Melee/" + transform.name;
        this.meleeDOSO = Resources.Load<DamageObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadMeleeDOSO " + resPath, gameObject);
    }

    protected void LoadMeleeDOMovement()
    {
        if (this.meleeDamageObjectMovement != null) return;
        this.meleeDamageObjectMovement = transform.GetComponentInChildren<MeleeDOMovement>();
        Debug.Log(transform.name + ": LoadMeleeDOMovement ", gameObject);
    }
}
