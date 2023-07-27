using UnityEngine;

public class MeleeDOCtrl : DOCtrl
{
    [SerializeField] protected MeleeSO meleeDOSO;
    public MeleeSO MeleeDOSO => meleeDOSO;

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
        meleeDamageObjectMovement.timeMove = meleeDOSO.timeAttack;
        doDamageSender.damage = meleeDOSO.damage;
        meleeDamageObjectMovement.timeMove = meleeDOSO.timeAttack;
        DamageObjectDespawn.despawnTime = meleeDOSO.timeAttack;
    }

    protected void LoadMeleeDOSO()
    {
        if (this.meleeDOSO != null) return;
        string resPath = "DamageObject/Melee/" + transform.name;
        this.meleeDOSO = Resources.Load<MeleeSO>(resPath);
        Debug.Log(transform.name + ": LoadMeleeDOSO " + resPath, gameObject);
    }

    protected void LoadMeleeDOMovement()
    {
        if (this.meleeDamageObjectMovement != null) return;
        this.meleeDamageObjectMovement = transform.GetComponentInChildren<MeleeDOMovement>();
        Debug.Log(transform.name + ": LoadMeleeDOMovement ", gameObject);
    }
}
