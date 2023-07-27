using UnityEngine;

public class DOCtrl : InitMonoBehaviour
{
    [SerializeField] protected DamageObjectSO damageObjectSO;
    public DamageObjectSO DamageObjectSO => damageObjectSO;

    [SerializeField] protected SpriteRenderer damageObjectSR;
    public SpriteRenderer DamageObjectSR => damageObjectSR;

    [SerializeField] protected DamageSender damageObjectDamageSender;
    public DamageSender DamageObjectDamageSender { get => damageObjectDamageSender; }

    [SerializeField] protected DespawnByTime damageObjectDespawn;
    public DespawnByTime DamageObjectDespawn { get => damageObjectDespawn; }

    [SerializeField] protected DOMovement damageObjectMovement;
    public DOMovement DamageObjectMovement { get => damageObjectMovement; }

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
        if (this.damageObjectSO == null) return;
        damageObjectSR.sprite = damageObjectSO.spriteInAttack;
        damageObjectDamageSender.SetDamage(damageObjectSO.damage);
        DamageObjectDespawn.despawnTime = damageObjectSO.attackTime;
        damageObjectMovement.SetTimeMovement(damageObjectSO.attackTime);
    }
    private void LoadDamageObjectMovement()
    {
        if (this.damageObjectMovement != null) return;
        this.damageObjectMovement = transform.GetComponentInChildren<DOMovement>();
        Debug.Log(transform.name + ": LoadDamageObjectMovement ", gameObject);
    }

    protected void LoadDamageObjectSR()
    {
        if (this.damageObjectSR != null) return;
        this.damageObjectSR = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadDamageObjectSR ", gameObject);
    }

    protected virtual void LoadDamageObjectDamageSender()
    {
        if (this.damageObjectDamageSender != null) return;
        this.damageObjectDamageSender = transform.GetComponentInChildren<DamageSender>();
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
        if (this.damageObjectSO != null) return;
        string resPathMelee = "DamageObject/Melee/" + transform.name;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPathMelee);
        Debug.Log(transform.name + ": LoadMeleeDOSO " + resPathMelee, gameObject);
        if (damageObjectSO != null) return;
        string resPathRanged = "DamageObject/Ranged/" + transform.name;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPathRanged);
        Debug.Log(transform.name + ": LoadMeleeDOSO " + resPathRanged, gameObject);
    }
}
