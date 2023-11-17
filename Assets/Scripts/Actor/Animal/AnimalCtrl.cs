using UnityEngine;

public class AnimalCtrl : InitMonoBehaviour
{
    [SerializeField] protected SpriteRenderer visual;

    [SerializeField] protected Animator animator;

    [SerializeField] protected AnimalDataSO animalData;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVisual();
        this.LoadAnimator();
    }

    protected override void ResetValue()
    {
        animalData = AnimalDataSO.FindByName(name);
        visual.sprite = animalData.visual;
        animator.runtimeAnimatorController = animalData.animator;
    }

    protected virtual void LoadVisual()
    {
        if (this.visual != null) return;
        visual = transform.Find("Visual").GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadVisual", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = transform.Find("Visual").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
