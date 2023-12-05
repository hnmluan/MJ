using UnityEngine;

public class UIInvItemSpawner : Spawner
{
    public static string normalItem = "Item";

    [SerializeField] private Transform content;
    public Transform Content => content;

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void ClearItems() { foreach (Transform item in this.holder) this.Despawn(item); }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.Spawn(UIInvItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}