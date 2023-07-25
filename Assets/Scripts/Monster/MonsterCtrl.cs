using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    [SerializeField] protected MonsterDespawn monsterDespawn;
    public MonsterDespawn MonsterDespawn { get => monsterDespawn; }

    [SerializeField] protected Slider heathBar;
    public Slider HeathBar { get => heathBar; }

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadMonsterDespawn();
        this.LoadModel();
        this.LoadHeathBar();
        this.LoadEnemySO();
    }

    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resPath);
        Debug.LogWarning(transform.name + ": LoadEnemySO " + resPath, gameObject);
    }

    protected virtual void LoadHeathBar()
    {
        if (this.heathBar != null) return;
        this.heathBar = transform.GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadHeathBar", gameObject);
    }

    private void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadMonsterDespawn()
    {
        if (this.monsterDespawn != null) return;
        this.monsterDespawn = transform.GetComponentInChildren<MonsterDespawn>();
        Debug.Log(transform.name + ": LoadMonsterDespawn", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
