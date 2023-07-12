using UnityEngine;

public class PlayerCtrl : InitMonoBehaviour

{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance { get => instance; }

    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected Rigidbody2D rb;

    public Rigidbody2D Rb { get => rb; }

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
        LoadRigidbody2D();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (rb != null) return;
        rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }
}
