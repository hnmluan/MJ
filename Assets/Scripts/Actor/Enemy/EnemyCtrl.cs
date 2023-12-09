using UnityEngine;

public class EnemyCtrl : InitMonoBehaviour
{
    [SerializeField] protected EnemyDataSO dataSO;
    public EnemyDataSO DataSO => dataSO;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected EnemyDespawn despawn;
    public EnemyDespawn Despawn { get => despawn; }

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected ObjAttackByDistance attack;
    public ObjAttackByDistance Attack => attack;

    [SerializeField] protected ObjFollowPlayer followPlayer;
    public ObjFollowPlayer FollowPlayer => followPlayer;

    [SerializeField] protected ObjMoveFree moveFree;
    public ObjMoveFree MoveFree => moveFree;

    private void Update()
    {
        bool isPlayerInTrackRange = Vector3.Distance(followPlayer.Target.position, transform.position) < dataSO.trackRange;

        moveFree.gameObject.SetActive(!isPlayerInTrackRange);
        followPlayer.gameObject.SetActive(isPlayerInTrackRange);
    }

    public void SetWeapon(Weapon weapon) => attack.SetWeapon(weapon);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadDespawn();
        this.LoadModel();
        this.LoadDamageReceiver();
        this.LoadAttack();
        this.LoadFollowPlayer();
        this.LoadMoveFree();
    }

    protected override void ResetValue()
    {
        dataSO = EnemyDataSO.FindByName(transform.name);
        if (dataSO == null)
        {
            Debug.Log("Don't find " + transform.name + " SO");
            return;
        }
        damageReceiver.SetHPMax(dataSO.hpMax);
        attack.SetRangeAttack(dataSO.acttackRange);
        moveFree.SetSpeed(dataSO.speed);
        followPlayer.SetSpeed(dataSO.speed);
        followPlayer.SetOutline(dataSO.nonMoveableRange);
        model.sprite = dataSO.visual;
        animator.runtimeAnimatorController = dataSO.animator;
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadAttack()
    {
        if (this.attack != null) return;
        this.attack = transform.GetComponentInChildren<ObjAttackByDistance>();
        Debug.Log(transform.name + ": LoadAttack", gameObject);
    }

    protected virtual void LoadFollowPlayer()
    {
        if (this.followPlayer != null) return;
        this.followPlayer = transform.GetComponentInChildren<ObjFollowPlayer>();
        Debug.Log(transform.name + ": LoadFollowPlayer", gameObject);
    }

    protected virtual void LoadMoveFree()
    {
        if (this.moveFree != null) return;
        this.moveFree = transform.GetComponentInChildren<ObjMoveFree>();
        Debug.Log(transform.name + ": LoadMoveFree", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
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
        Gizmos.DrawWireSphere(transform.position, dataSO.trackRange);
    }
}
