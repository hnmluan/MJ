using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb { get => rb; }

    [SerializeField] protected ObjAttack attack;
    public ObjAttack Attack { get => attack; }

    [SerializeField] protected PlayerMovement movement;
    public PlayerMovement Movement { get => movement; }

    [SerializeField] protected Slider hpBar;
    public Slider HPBar { get => hpBar; }

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model { get => model; }

    protected override void ResetValue() => this.tag = "Player";

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadAttack();
        this.LoadMovement();
        this.LoadModel();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }

    protected virtual void LoadAttack()
    {
        if (this.attack != null) return;
        this.attack = transform.GetComponentInChildren<ObjAttack>();
        Debug.Log(transform.name + ": LoadAttack", gameObject);
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadMovement", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
