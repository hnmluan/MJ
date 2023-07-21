using UnityEngine;

public class MonsterCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    [SerializeField] protected MonsterDespawn monsterDespawn;
    public MonsterDespawn MonsterDespawn { get => monsterDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadMonsterDespawn();
        this.LoadModel();
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
