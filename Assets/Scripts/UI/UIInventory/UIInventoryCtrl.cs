using UnityEngine;

public class UIInventoryCtrl : InitMonoBehaviour
{
    private static UIInventoryCtrl instance;
    public static UIInventoryCtrl Instance => instance;

    [Header("Inv Item Spawner")]
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIInvItemSpawner invItemSpawner;
    public UIInvItemSpawner UIInvItemSpawner => invItemSpawner;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventoryCtrl.instance != null) Debug.LogError("Only 1 UIInventoryCtrl allow to exist");
        UIInventoryCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInvItemSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIInvItemSpawner()
    {
        if (this.invItemSpawner != null) return;
        this.invItemSpawner = transform.GetComponentInChildren<UIInvItemSpawner>();
        Debug.Log(transform.name + ": LoadUIInvItemSpawner", gameObject);
    }
}