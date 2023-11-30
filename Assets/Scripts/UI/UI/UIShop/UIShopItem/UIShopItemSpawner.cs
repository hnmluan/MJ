using UnityEngine;

public class UIShopItemSpawner : Spawner
{
    [SerializeField] protected Transform content;

    public static string normalItem = "UIShopItem";

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void ClearItems()
    {
        foreach (Transform item in this.holder) this.Despawn(item);
    }

    public virtual void SpawnItem(ItemShop item)
    {
        Transform uiItem = this.Spawn(UIShopItemSpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemShop itemShop = uiItem.GetComponent<UIItemShop>();
        itemShop.ShowItem(item);

        uiItem.gameObject.SetActive(true);
    }
}