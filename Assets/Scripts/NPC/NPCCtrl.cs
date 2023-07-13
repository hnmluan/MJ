using UnityEngine;

public class NPCCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected SpriteRenderer npcSprite;
    public SpriteRenderer NPCSprite { get => npcSprite; }

    [SerializeField] protected GameObject dialogConversable;
    public GameObject DialogConversable { get => dialogConversable; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadNPCSprite();
        this.LoadDialogConversable();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadNPCSprite()
    {
        if (this.npcSprite != null) return;
        this.npcSprite = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadPlayerSprite", gameObject);
    }

    protected virtual void LoadDialogConversable()
    {
        if (this.dialogConversable != null) return;
        this.dialogConversable = GameObject.Find("DialogConversable"); ;
        Debug.Log(transform.name + ": LoadDialogConversable", gameObject);
    }
}
