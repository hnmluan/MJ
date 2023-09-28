using UnityEngine;

public class UIInventoryCtrl : InitMonoBehaviour
{
    private static UIInventoryCtrl instance;
    public static UIInventoryCtrl Instance => instance;

    [Header("Inv Item Spawner")]
    [SerializeField] protected Transform content;
    public Transform Content => content;


    protected override void Awake()
    {
        base.Awake();
        if (UIInventoryCtrl.instance != null) Debug.Log("Only 1 UIInventoryCtrl allow to exist");
        UIInventoryCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }
}