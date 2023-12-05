using Assets.SimpleLocalization;

public class UIInvDetail : UIInvDetailAbstract
{
    public virtual void Show()
    {
        ItemInventory item = UIInventory.Instance.CurrentItem;

        uiCtrl.ItemImage.sprite = item.itemProfile.itemSprite;
        uiCtrl.ItemQuantity.text = item.itemCount.ToString();
        uiCtrl.ItemName.text = LocalizationManager.Localize(item.itemProfile.keyName);
        uiCtrl.ItemDescription.text = LocalizationManager.Localize(item.itemProfile.keyDescription);
        uiCtrl.ItemType.text = LocalizationManager.Localize("Item.Type." + item.itemProfile.itemType.ToString());

        uiCtrl.BtnInvUse.transform.gameObject.SetActive(IsTreasureItem());
        uiCtrl.BtnInvUseAll.transform.gameObject.SetActive(IsTreasureItem() && item.itemCount > 1);
        uiCtrl.BtnInvBuy.transform.gameObject.SetActive(IsSellableItem());
        uiCtrl.BtnInvBuyAll.transform.gameObject.SetActive(IsSellableItem() && item.itemCount > 1);
    }

    public virtual void Clear()
    {
        uiCtrl.ItemImage.sprite = null;
        uiCtrl.ItemDescription.text = null;
        uiCtrl.ItemName.text = null;
        uiCtrl.ItemQuantity.text = null;
        uiCtrl.ItemType.text = null;
        uiCtrl.BtnInvUse.transform.gameObject.SetActive(false);
        uiCtrl.BtnInvUseAll.transform.gameObject.SetActive(false);
        uiCtrl.BtnInvBuy.transform.gameObject.SetActive(false);
        uiCtrl.BtnInvBuyAll.transform.gameObject.SetActive(false);
    }

    private bool IsTreasureItem() => UIInventory.Instance.CurrentItem.itemProfile.IsExistItemData<ItemOpenTreasureData>();

    private bool IsSellableItem() => UIInventory.Instance.CurrentItem.itemProfile.IsExistItemData<ItemSellAcctionData>();
}
