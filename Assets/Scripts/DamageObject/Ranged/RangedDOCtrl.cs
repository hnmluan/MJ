using UnityEngine;

public class RangedDOCtrl : InitMonoBehaviour
{
    [SerializeField] protected DamageObjectSO damageObjectSO;
    public DamageObjectSO DamageObjectSO => damageObjectSO;

    [SerializeField] protected SpriteRenderer modelSpriteRenderer;
    public SpriteRenderer ModelSpriteRenderer => modelSpriteRenderer;

    [SerializeField] protected RangedDOMovement rangedDamageObjectMovement;
    public RangedDOMovement RangedDamageObjectMovement => rangedDamageObjectMovement;

    [SerializeField] protected RangedDODamageSender damageSender;
    public RangedDODamageSender DamageSender { get => damageSender; }

    [SerializeField] protected RangedDODespawn despawnDO;
    public RangedDODespawn DespawnDO { get => despawnDO; }


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRangedDOSO();

        this.LoadRangedDOModel();

        this.LoadRangedDOMovement();

        this.LoadRangedDODamageSender();

        this.LoadRangedDODespawn();
    }

    protected override void ResetValue()
    {
        if (this.damageObjectSO == null) return;
        modelSpriteRenderer.sprite = damageObjectSO.spriteInAttack;
        rangedDamageObjectMovement.movespeed = damageObjectSO.speed;
        damageSender.damage = damageObjectSO.damage;
        despawnDO.despawnTime = damageObjectSO.range / damageObjectSO.speed;
    }

    protected virtual void LoadRangedDOSO()
    {
        if (this.damageObjectSO != null) return;
        string resPath = "DamageObject/Ranged/" + transform.name;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadRangedDOSO " + resPath, gameObject);
    }

    protected void LoadRangedDOModel()
    {
        if (this.modelSpriteRenderer != null) return;
        this.modelSpriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadRangedDOModel ", gameObject);
    }

    protected void LoadRangedDOMovement()
    {
        if (this.rangedDamageObjectMovement != null) return;
        this.rangedDamageObjectMovement = transform.GetComponentInChildren<RangedDOMovement>();
        Debug.Log(transform.name + ": LoadRangedDOMovement ", gameObject);
    }

    protected virtual void LoadRangedDODamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<RangedDODamageSender>();
        Debug.Log(transform.name + ": LoadRangedDODamageSender", gameObject);
    }

    protected virtual void LoadRangedDODespawn()
    {
        if (this.despawnDO != null) return;
        this.despawnDO = transform.GetComponentInChildren<RangedDODespawn>();
        Debug.Log(transform.name + ": LoadRangedDODespawn", gameObject);
    }
}
