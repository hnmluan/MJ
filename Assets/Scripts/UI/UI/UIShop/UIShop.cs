public class UIShop : BaseUI<UIShop>
{
    protected override void OnEnable() => RefreshUI();

    public void RefreshUI()
    {
        UIShopItemSpawner.Instance.ClearItems();
        foreach (ItemShop item in Shop.Instance.listItem) UIShopItemSpawner.Instance.SpawnItem(item);
    }
}
