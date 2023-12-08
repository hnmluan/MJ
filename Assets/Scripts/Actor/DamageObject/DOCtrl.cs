using UnityEngine;

public class DOCtrl : InitMonoBehaviour
{
    [SerializeField] protected WeaponDataSO data;
    public WeaponDataSO Data => data;

    [SerializeField] protected int level;
    public int Level => level;

    [SerializeField] protected SpriteRenderer sprite;
    public SpriteRenderer Sprite => sprite;

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender { get => damageSender; }

    [SerializeField] protected DespawnByTime despawn;
    public DespawnByTime Despawn { get => despawn; }

    [SerializeField] protected DOMovement movement;
    public DOMovement Movement { get => movement; }

    [SerializeField] protected string attacker;
    public string Attacker => attacker;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSprite();
        this.LoadDamageSender();
        this.LoadDespawn();
        this.LoadData();
        this.LoadMovement();
    }

    protected override void OnEnable()
    {
        if (this.data == null) return;
        damageSender.SetDamage(data.levels[level].damage);
    }

    protected override void ResetValue()
    {
        if (this.data == null) return;
        sprite.sprite = data.spriteInAttack;
        damageSender.SetDamage(data.levels[0].damage);
        despawn.SetTimeDespawn(data.attackTime);
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

    protected virtual void LoadSprite()
    {
        if (this.sprite != null) return;
        this.sprite = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadSprite ", gameObject);
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

    protected virtual void LoadData() => this.data = WeaponDataSO.FindByName(transform.name);


}
