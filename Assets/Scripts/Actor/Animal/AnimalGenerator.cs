using UnityEngine;

public class AnimalGenerator : InitMonoBehaviour
{
    [SerializeField] protected SpriteRenderer visual;

    [SerializeField] protected Animator animator;

    [SerializeField] protected AnimalDataSO characterData;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimalData();
        this.LoadVisual();
        this.LoadAnimator();
    }

    private void LoadAnimalData()
    {
        if (this.characterData != null) return;
        characterData = AnimalDataSO.FindByName(name);
        Debug.Log(transform.name + ": LoadAnimalData", gameObject);
    }

    private void LoadVisual()
    {
        if (this.visual != null) return;
        visual = transform.Find("Visual").GetComponent<SpriteRenderer>();
        visual.sprite = characterData.visual;
        Debug.Log(transform.name + ": LoadVisual", gameObject);
    }

    private void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = transform.Find("Visual").GetComponent<Animator>();
        animator.runtimeAnimatorController = characterData.animator;
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
