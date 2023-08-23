using UnityEngine;

public class AnimalCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    public RuntimeAnimatorController animatorController;

    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadAnimatorController();
        this.LoadModel();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadAnimatorController()
    {
        if (this.animator != null && animatorController != null) return;
        animator.runtimeAnimatorController = animatorController;
        Debug.Log(transform.name + ": LoadAnimatorController", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
