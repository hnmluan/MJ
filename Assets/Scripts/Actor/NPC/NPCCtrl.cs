using UnityEngine;

public class NPCCtrl : InitMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] protected SpriteRenderer npcSR;
    public SpriteRenderer NPCSprite { get => npcSR; }

    [SerializeField] protected GameObject dialogConversable;
    public GameObject DialogConversable { get => dialogConversable; }

    [SerializeField] protected NPCProfileSO npcSO;
    public NPCProfileSO NPCSO => npcSO;

    [SerializeField] protected ObjMoveToPlayer objMoveToPlayer;
    public ObjMoveToPlayer ObjMoveToPlayer => objMoveToPlayer;

    [SerializeField] protected ObjMoveFree objMoveFree;
    public ObjMoveFree ObjMoveFree => objMoveFree;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadNPCSprite();
        this.LoadDialogConversable();
        this.LoadNPCSO();
        this.LoadObjMoveToPlayer();
        this.LoadObjMoveFree();
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

    protected virtual void LoadObjMoveToPlayer()
    {
        if (this.objMoveToPlayer != null) return;
        this.objMoveToPlayer = transform.GetComponentInChildren<ObjMoveToPlayer>();
        Debug.Log(transform.name + ": LoadObjMoveToPlayer", gameObject);
    }

    protected virtual void LoadObjMoveFree()
    {
        if (this.objMoveFree != null) return;
        this.objMoveFree = transform.GetComponentInChildren<ObjMoveFree>();
        Debug.Log(transform.name + ": LoadObjMoveFree", gameObject);
    }

    protected virtual void LoadNPCSO()
    {
        if (this.npcSO != null) return;
        string resPath = "NPC/ScriptableObject/" + transform.name;
        this.npcSO = Resources.Load<NPCProfileSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadNPCSO " + resPath, gameObject);
    }
}
