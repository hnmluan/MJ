using UnityEngine;

public class UIDictionaryCtrl : InitMonoBehaviour
{
    private static UIDictionaryCtrl instance;
    public static UIDictionaryCtrl Instance => instance;

    [Header("Dictionary Item Spawner")]
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIDictionaryItemSpawner dictionaryItemSpawner;
    public UIDictionaryItemSpawner UIDictionaryItemSpawner => dictionaryItemSpawner;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionaryCtrl.instance != null) Debug.Log("Only 1 UIDictionaryCtrl allow to exist");
        UIDictionaryCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIDictionaryItemSpawner();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIDictionaryItemSpawner()
    {
        if (this.dictionaryItemSpawner != null) return;
        this.dictionaryItemSpawner = transform.GetComponentInChildren<UIDictionaryItemSpawner>();
        Debug.Log(transform.name + ": LoadUIDictionaryItemSpawner", gameObject);
    }
}