using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : InitMonoBehaviour
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

    //[SerializeField] protected PlayerInteract playerInteract;
    //public PlayerInteract PlayerInteract { get => playerInteract; }

    [SerializeField] protected Slider hpBar;
    public Slider HPBar { get => hpBar; }

    [SerializeField] protected SpriteRenderer playerSprite;
    public SpriteRenderer PlayerSprite { get => playerSprite; }

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory { get => inventory; }

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPlayerAttack();
        this.LoadPlayerMovement();
        //this.LoadPlayerInteract();
        this.LoadHPBar();
        this.LoadPlayerSprite();
        //this.LoadHealthBlink();
        this.LoadRigidbody2D();
        this.LoadInventory();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
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

    //protected virtual void LoadPlayerInteract()
    //{
    //    if (this.playerInteract != null) return;
    //    this.playerInteract = transform.GetComponentInChildren<PlayerInteract>();
    //    Debug.Log(transform.name + ": LoadPlayerInteract", gameObject);
    //}

    protected virtual void LoadHPBar()
    {
        if (this.hpBar != null) return;
        this.hpBar = transform.GetComponentInChildren<Slider>();
        Debug.Log(transform.name + ": LoadHeathBar", gameObject);
    }

    protected virtual void LoadPlayerSprite()
    {
        if (this.playerSprite != null) return;
        this.playerSprite = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadPlayerSprite", gameObject);
    }

    //protected virtual void LoadHealthBlink()
    //{
    //    if (this.healthBlink != null) return;
    //    this.healthBlink = transform.GetComponentInChildren<HealthBlink>();
    //    Debug.Log(transform.name + ": LoadHealthBlink", gameObject);
    //}

    //public void DisableAllActions()
    //{
    //    playerMovement.gameObject.SetActive(false);
    //    playerInteract.gameObject.SetActive(false);
    //    playerAttack.gameObject.SetActive(false);
    //    Debug.Log("DisableAllActions");
    //}

    //public void EnableAllActions()
    //{
    //    playerMovement.gameObject.SetActive(true);
    //    playerInteract.gameObject.SetActive(true);
    //    playerAttack.gameObject.SetActive(true);
    //}
}
