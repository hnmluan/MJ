using UnityEngine;

public class UIDictionaryItemSpawner : Spawner
{
    private static UIDictionaryItemSpawner instance;
    public static UIDictionaryItemSpawner Instance => instance;

    public static string normalItem = "UIDictionaryItem";

    [Header("Dictionary Item Spawner")]

    [SerializeField] protected UIDictionaryCtrl dictionaryCtrl;
    public UIDictionaryCtrl UIDictionaryCtrl => dictionaryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionaryItemSpawner.instance != null) Debug.LogError("Only 1 UIDictionaryItemSpawner allow to exist");
        UIDictionaryItemSpawner.instance = this;
    }

    protected override void LoadHolder()
    {
        this.LoadUIDictionaryCtrl();

        if (this.holder != null) return;
        this.holder = this.dictionaryCtrl.Content;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    protected virtual void LoadUIDictionaryCtrl()
    {
        if (this.dictionaryCtrl != null) return;
        this.dictionaryCtrl = transform.parent.GetComponent<UIDictionaryCtrl>();
        Debug.LogWarning(transform.name + ": LoadUIDictionaryCtrl", gameObject);
    }

    public virtual void ClearItems()
    {
        foreach (Transform item in this.holder) this.Despawn(item);
    }

    public virtual void SpawnItem(ScriptableObject item)
    {
        Transform uiItem = this.dictionaryCtrl.UIDictionaryItemSpawner.Spawn(UIDictionaryItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemDictionary itemDictionary = uiItem.GetComponent<UIItemDictionary>();
        itemDictionary.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}