using UnityEngine;

public class DOCtrl : InitMonoBehaviour
{
    [SerializeField] protected WeaponDataSO dataSO;
    public WeaponDataSO Data => dataSO;

    [SerializeField] protected int level;
    public int Level => level;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected DODamageSender damageSender;
    public DODamageSender DamageSender { get => damageSender; }

    [SerializeField] protected DespawnByTime despawn;
    public DespawnByTime Despawn { get => despawn; }

    [SerializeField] protected DOMovement movement;
    public DOMovement Movement { get => movement; }

    [SerializeField] protected string attacker;
    public string Attacker => attacker;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDamageSender();
        this.LoadDespawn();
        this.LoadData();
        this.LoadMovement();
    }

    protected override void OnEnable()
    {
        if (this.dataSO == null) return;
        damageSender.SetDamage(dataSO.levels[level].damage);
    }

    protected override void ResetValue()
    {
        if (this.dataSO == null) return;
        model.sprite = dataSO.spriteInAttack;
        damageSender.SetDamage(dataSO.levels[0].damage);
        despawn.SetTimeDespawn(dataSO.attackTime);
        movement.ResetMotionParameters();
    }

    public virtual void SetAttacker(string attacker) => this.attacker = attacker;

    public virtual void SetLevel(int level) => this.level = level;

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<DOMovement>();
        Debug.Log(transform.name + ": LoadMovement ", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel ", gameObject);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnByTime>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }

    protected virtual void LoadData() => this.dataSO = WeaponDataSO.FindByName(transform.name);
}
