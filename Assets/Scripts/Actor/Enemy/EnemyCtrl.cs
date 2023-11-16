using UnityEngine;

public class EnemyCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    [SerializeField] protected EnemyDataSO enemySO;
    public EnemyDataSO EnemySO => enemySO;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySO();
        this.LoadAnimator();
        this.LoadEnemyDespawn();
        this.LoadVisual();
        this.LoadDamageReceiver();
    }

    protected override void ResetValue()
    {
        if (enemySO == null) return;
        damageReceiver.HPMax = enemySO.hpMax;
    }

    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/ScriptableObject/" + transform.name;
        this.enemySO = Resources.Load<EnemyDataSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadEnemySO " + resPath, gameObject);
    }

    protected virtual void LoadVisual()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        model.sprite = enemySO.visual;
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ": LoadEnemyDespawn", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        animator.runtimeAnimatorController = enemySO.animator;
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
