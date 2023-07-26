using UnityEngine;

public class MeleeDOCtrl : InitMonoBehaviour
{
    [SerializeField] protected MeleeSO meleeDOSO;
    public MeleeSO MeleeDOSO => meleeDOSO;

    [SerializeField] protected SpriteRenderer modelSpriteRenderer;
    public SpriteRenderer ModelSpriteRenderer => modelSpriteRenderer;

    [SerializeField] protected MeleeDOMovement meleeDamageObjectMovement;
    public MeleeDOMovement MeleeDamageObjectMovement => meleeDamageObjectMovement;

    [SerializeField] protected MeleeDODamageSender damageSender;
    public MeleeDODamageSender DamageSender { get => damageSender; }

    [SerializeField] protected MeleeDODespawn despawnDO;
    public MeleeDODespawn DespawnDO { get => despawnDO; }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadMeleeDOSO();

        this.LoadMeleeDOModel();

        this.LoadMeleeDOMovement();

        this.LoadMeleeDODamageSender();

        this.LoadMeleeDODespawn();
    }

    protected override void ResetValue()
    {
        if (this.meleeDOSO == null) return;
        modelSpriteRenderer.sprite = meleeDOSO.spriteInAttack;
        meleeDamageObjectMovement.timeMove = meleeDOSO.timeAttack;
        damageSender.damage = meleeDOSO.damage;
        meleeDamageObjectMovement.timeMove = meleeDOSO.timeAttack;
        despawnDO.despawnTime = meleeDOSO.timeAttack;
    }

    protected virtual void LoadMeleeDOSO()
    {
        if (this.meleeDOSO != null) return;
        string resPath = "DamageObject/Melee/" + transform.name;
        this.meleeDOSO = Resources.Load<MeleeSO>(resPath);
        Debug.Log(transform.name + ": LoadMeleeDOSO " + resPath, gameObject);
    }

    protected void LoadMeleeDOModel()
    {
        if (this.modelSpriteRenderer != null) return;
        this.modelSpriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadMeleeDOModel ", gameObject);
    }

    protected void LoadMeleeDOMovement()
    {
        if (this.meleeDamageObjectMovement != null) return;
        this.meleeDamageObjectMovement = transform.GetComponentInChildren<MeleeDOMovement>();
        Debug.Log(transform.name + ": LoadMeleeDOMovement ", gameObject);
    }

    protected virtual void LoadMeleeDODamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<MeleeDODamageSender>();
        Debug.Log(transform.name + ": LoadMeleeDODamageSender", gameObject);
    }

    protected virtual void LoadMeleeDODespawn()
    {
        if (this.despawnDO != null) return;
        this.despawnDO = transform.GetComponentInChildren<MeleeDODespawn>();
        Debug.Log(transform.name + ": LoadMeleeDODespawn", gameObject);
    }
}
