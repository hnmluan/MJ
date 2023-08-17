using UnityEngine;

public class DOCtrl : InitMonoBehaviour
{
    [SerializeField] protected WeaponProfileSO doSO;
    public WeaponProfileSO DOSO => doSO;

    [SerializeField] protected SpriteRenderer doSR;
    public SpriteRenderer DOSR => doSR;

    [SerializeField] protected DamageSender doDamageSender;
    public DamageSender DODamageSender { get => doDamageSender; }

    [SerializeField] protected DespawnByTime damageObjectDespawn;
    public DespawnByTime DamageObjectDespawn { get => damageObjectDespawn; }

    [SerializeField] protected DOMovement damageObjectMovement;
    public DOMovement DamageObjectMovement { get => damageObjectMovement; }

    [SerializeField] protected Transform attacker;
    public Transform Attacker => attacker;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectSR();
        this.LoadDamageObjectDamageSender();
        this.LoadDamageObjectDespawn();
        this.LoadDamageObjectSO();
        this.LoadDamageObjectMovement();
    }

    protected override void ResetValue()
    {
        if (this.doSO == null) return;
        doSR.sprite = doSO.spriteInAttack;
        doDamageSender.SetDamage(doSO.damage);
        damageObjectDespawn.SetTimeDespawn(doSO.attackTime);
        damageObjectMovement.ResetMotionParameters();
    }

    public virtual void SetAttacker(Transform attacker) => this.attacker = attacker;

    private void LoadDamageObjectMovement()
    {
        if (this.damageObjectMovement != null) return;
        this.damageObjectMovement = transform.GetComponentInChildren<DOMovement>();
        Debug.Log(transform.name + ": LoadDamageObjectMovement ", gameObject);
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
    private void LoadDamageObjectSO()
    {
        if (this.doSO != null) return;
        string resPathMelee = "DamageObject/Melee/" + transform.name;
        string resPathRanged = "DamageObject/Ranged/" + transform.name;

        this.doSO = Resources.Load<WeaponProfileSO>(resPathMelee) != null ? Resources.Load<WeaponProfileSO>(resPathMelee) : Resources.Load<WeaponProfileSO>(resPathRanged);
        string resPath = Resources.Load<WeaponProfileSO>(resPathMelee) != null ? resPathMelee : resPathRanged;

        Debug.Log(transform.name + ": LoadMeleeDOSO" + resPath, gameObject);
    }

}
