using UnityEngine;

public class NPCCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected SpriteRenderer npcSR;
    public SpriteRenderer NPCSprite { get => npcSR; }

    [SerializeField] protected GameObject dialogConversable;
    public GameObject DialogConversable { get => dialogConversable; }

    [SerializeField] protected NPCSO npcSO;
    public NPCSO NPCSO => npcSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadNPCSprite();
        this.LoadDialogConversable();
        this.LoadNPCSO();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadNPCSprite()
    {
        if (this.npcSR != null) return;
        this.npcSR = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadPlayerSprite", gameObject);
    }

    protected virtual void LoadDialogConversable()
    {
        if (this.dialogConversable != null) return;
        this.dialogConversable = GameObject.Find("CommunicativeSign"); ;
        Debug.Log(transform.name + ": LoadDialogConversable", gameObject);
    }

    protected virtual void LoadNPCSO()
    {
        if (this.npcSO != null) return;
        string resPath = "NPC/" + transform.name;
        this.npcSO = Resources.Load<NPCSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadNPCSO " + resPath, gameObject);
    }
}
