using UnityEngine;

public class UIShop : BaseUI<UIShop>
{
    [SerializeField] protected UIShopItemSpawner shopItemSpawner;

    protected override void OnEnable() => RefreshUI();

    public void RefreshUI()
    {
        shopItemSpawner.ClearItems();
        foreach (ItemShop item in Shop.Instance.listItem) shopItemSpawner.SpawnItem(item);
    }
}
