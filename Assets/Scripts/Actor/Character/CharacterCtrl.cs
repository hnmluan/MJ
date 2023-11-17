using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCtrl : InitMonoBehaviour
{
    [SerializeField] protected SpriteRenderer visual;

    [SerializeField] protected Animator animator;

    [SerializeField] protected LocalizedText keyName;

    [SerializeField] protected ObjMoveToPlayer enemyMoveToPlayer;
    public ObjMoveToPlayer ObjMoveToPlayer => enemyMoveToPlayer;

    [SerializeField] protected ObjMoveFree enemyMoveFree;
    public ObjMoveFree ObjMoveFree => enemyMoveFree;

    [SerializeField] protected CharacterDataSO characterData;

    [SerializeField] private GameObject visualCue;
    public GameObject VisualCue => visualCue;

    [SerializeField] private Animator emoteAnimator;
    public Animator EmoteAnimator => emoteAnimator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVisual();
        this.LoadAnimator();
        this.LoadKeyName();
        this.LoadObjMoveToPlayer();
        this.LoadObjMoveFree();
        this.LoadVisualCue();
        this.LoadEmoteAnimator();
    }

    protected override void ResetValue()
    {
        characterData = CharacterDataSO.FindByName(transform.name);
        visual.sprite = characterData.visual;
        animator.runtimeAnimatorController = characterData.animator;
        keyName.LocalizationKey = characterData.keyName;
        GetComponentInChildren<Text>().text = LocalizationManager.Localize(characterData.keyName);
    }

    protected virtual void LoadObjMoveToPlayer()
    {
        if (this.enemyMoveToPlayer != null) return;
        this.enemyMoveToPlayer = transform.GetComponentInChildren<ObjMoveToPlayer>();
        Debug.Log(transform.name + ": LoadObjMoveToPlayer", gameObject);
    }

    protected virtual void LoadObjMoveFree()
    {
        if (this.enemyMoveFree != null) return;
        this.enemyMoveFree = transform.GetComponentInChildren<ObjMoveFree>();
        Debug.Log(transform.name + ": LoadObjMoveFree", gameObject);
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

    protected virtual void LoadKeyName()
    {
        if (this.keyName != null) return;
        keyName = GetComponentInChildren<LocalizedText>();
        Debug.Log(transform.name + ": LoadKeyName", gameObject);
    }

    protected virtual void LoadVisualCue()
    {
        if (this.visualCue != null) return;
        visualCue = transform.Find("VisualCue").gameObject;
        Debug.Log(transform.name + ": LoadVisualCue", gameObject);
    }

    protected virtual void LoadEmoteAnimator()
    {
        if (this.emoteAnimator != null) return;
        this.emoteAnimator = transform.Find("EmoteIcon").Find("EmoteIconVisual").GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadEmoteAnimator", gameObject);
    }
}
