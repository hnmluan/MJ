using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb { get => rb; }

    [SerializeField] protected ObjAttack objAttack;
    public ObjAttack ObjAttack { get => objAttack; }

    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement { get => playerMovement; }

    [SerializeField] protected Slider hpBar;
    public Slider HPBar { get => hpBar; }

    [SerializeField] protected SpriteRenderer playerSprite;
    public SpriteRenderer PlayerSprite { get => playerSprite; }

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.Log("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPlayerAttack();
        this.LoadPlayerMovement();
        this.LoadPlayerSprite();
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

    protected virtual void LoadPlayerAttack()
    {
        if (this.objAttack != null) return;
        this.objAttack = transform.GetComponentInChildren<ObjAttack>();
        Debug.Log(transform.name + ": LoadPlayerAttack", gameObject);
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = transform.GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + ": LoadPlayerMovement", gameObject);
    }

    protected virtual void LoadPlayerSprite()
    {
        if (this.playerSprite != null) return;
        this.playerSprite = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadPlayerSprite", gameObject);
    }
}
