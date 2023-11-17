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

    [SerializeField] protected ObjAttackByDistance enemyAttack;
    public ObjAttackByDistance EnemyAttack => enemyAttack;

    [SerializeField] protected ObjMoveToPlayer enemyMoveToPlayer;
    public ObjMoveToPlayer EnemyMoveToPlayer => enemyMoveToPlayer;

    [SerializeField] protected ObjMoveFree enemyMoveFree;
    public ObjMoveFree EnemyMoveFree => enemyMoveFree;

    private void Update()
    {
        if (Vector3.Distance(enemyMoveToPlayer.Target.position, transform.position) > enemySO.trackRange)
        {
            enemyMoveFree.gameObject.SetActive(true);
            enemyMoveToPlayer.gameObject.SetActive(false);
        }
        else
        {
            enemyMoveFree.gameObject.SetActive(false);
            enemyMoveToPlayer.gameObject.SetActive(true);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadEnemyDespawn();
        this.LoadVisual();
        this.LoadDamageReceiver();
        this.LoadEnemyAttack();
        this.LoadEnemyMoveToPlayer();
        this.LoadEnemyMoveFree();
    }

    protected override void ResetValue()
    {
        enemySO = EnemyDataSO.FindByName(transform.name);
        if (enemySO == null)
        {
            Debug.Log("Don't find " + transform.name + " SO");
            return;
        }
        damageReceiver.SetHPMax(enemySO.hpMax);
        enemyAttack.SetRangeAttack(enemySO.acttackRange);
        enemyMoveFree.SetSpeed(enemySO.speed);
        enemyMoveToPlayer.SetSpeed(enemySO.speed);
        enemyMoveToPlayer.SetOutline(enemySO.nonMoveableRange);
        model.sprite = enemySO.visual;
        animator.runtimeAnimatorController = enemySO.animator;
    }

    protected virtual void LoadVisual()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadEnemyAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = transform.GetComponentInChildren<ObjAttackByDistance>();
        Debug.Log(transform.name + ": LoadEnemyAttack", gameObject);
    }

    protected virtual void LoadEnemyMoveToPlayer()
    {
        if (this.enemyMoveToPlayer != null) return;
        this.enemyMoveToPlayer = transform.GetComponentInChildren<ObjMoveToPlayer>();
        Debug.Log(transform.name + ": LoadEnemyMoveToPlayer", gameObject);
    }

    protected virtual void LoadEnemyMoveFree()
    {
        if (this.enemyMoveFree != null) return;
        this.enemyMoveFree = transform.GetComponentInChildren<ObjMoveFree>();
        Debug.Log(transform.name + ": LoadEnemyMoveFree", gameObject);
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
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemySO.trackRange);
    }
}
    