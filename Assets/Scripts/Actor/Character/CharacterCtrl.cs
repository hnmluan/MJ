using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCtrl : InitMonoBehaviour
{
    [SerializeField] protected CharacterDataSO dataSO;
    public CharacterDataSO DataSO => dataSO;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected ObjFollowPlayer followPlayer;
    public ObjFollowPlayer FollowPlayer => followPlayer;

    [SerializeField] protected ObjMoveFree moveFree;
    public ObjMoveFree MoveFree => moveFree;

    [SerializeField] private GameObject visualCue;
    public GameObject VisualCue => visualCue;

    [SerializeField] private Animator emoteAnimator;
    public Animator EmoteAnimator => emoteAnimator;

    [SerializeField] protected LocalizedText keyName;
    public LocalizedText KeyName => keyName;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDataSO();
        this.LoadModel();
        this.LoadAnimator();
        this.LoadName();
        this.LoadFollowPlayer();
        this.LoadMoveFree();
        this.LoadVisualCue();
        this.LoadEmoteAnimator();
    }

    protected override void ResetValue()
    {
        if (dataSO == null) return;
        model.sprite = dataSO.visual;
        animator.runtimeAnimatorController = dataSO.animator;
        keyName.LocalizationKey = dataSO.keyName;
        GetComponentInChildren<Text>().text = LocalizationManager.Localize(dataSO.keyName);
    }
    protected virtual void LoadDataSO()
    {
        this.dataSO = CharacterDataSO.FindByName(transform.name);
        if (dataSO == null) Debug.Log(transform.name + ": Dont found DataSO", gameObject);
    }

    protected virtual void LoadFollowPlayer()
    {
        if (this.followPlayer != null) return;
        this.followPlayer = transform.GetComponentInChildren<ObjFollowPlayer>();
        Debug.Log(transform.name + ": LoadFollowPlayer", gameObject);
    }

    protected virtual void LoadMoveFree()
    {
        if (this.moveFree != null) return;
        this.moveFree = transform.GetComponentInChildren<ObjMoveFree>();
        Debug.Log(transform.name + ": LoadMoveFree", gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        model = transform.Find("Model").GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = transform.Find("Model").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadName()
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
