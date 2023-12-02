using UnityEngine;

public class UIDictionaryItemSpawner : Spawner
{
    public static string normalItem = "UIDictionaryItem";

    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void ClearItems()
    {
        foreach (Transform item in this.holder) this.Despawn(item);
    }

    public virtual void SpawnItem(ScriptableObject item)
    {
        Transform uiItem = this.Spawn(UIDictionaryItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemDictionary itemDictionary = uiItem.GetComponent<UIItemDictionary>();
        itemDictionary.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}