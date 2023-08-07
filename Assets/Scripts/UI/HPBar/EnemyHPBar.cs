using UnityEngine;

public class EnemyHPBar : InitMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected SliderHp sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate() => this.HPShowing();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.LogWarning(transform.name + ": LoadSliderHp", gameObject);
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void HPShowing()
    {
        if (this.enemyCtrl == null) return;
        bool isDead = this.enemyCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }

        float hp = this.enemyCtrl.DamageReceiver.HP;
        float maxHp = this.enemyCtrl.DamageReceiver.HPMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(maxHp);
    }

    public virtual void SetObjectCtrl(EnemyCtrl enemyCtrl) => this.enemyCtrl = enemyCtrl;

    public virtual void SetFollowTarget(Transform target) => this.followTarget.SetTarget(target);
}