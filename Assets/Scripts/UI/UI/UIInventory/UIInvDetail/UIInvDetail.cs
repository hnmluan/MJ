using Assets.SimpleLocalization;
using UnityEngine;

public class UIInvDetail : UIInvDetailAbstract
{
    [Header("UI Inventory Detail")]

    private static UIInvDetail instance;
    public static UIInvDetail Instance => instance;

    [SerializeField] protected ItemInventory itemInventory = null;
    public ItemInventory ItemInventory => itemInventory;

    protected override void Awake()
    {
        base.Awake();
        if (UIInvDetail.instance != null) Debug.Log("Only 1 UIInvDetail allow to exist");
        UIInvDetail.instance = this;
    }

    protected override void OnDisable() => this.SetEmptyUIInvDetail();

    public virtual void SetUIInvDetail(ItemInventory item)
    {
        this.itemInventory = item;

        ShowButtons();

        uiInvDetailCtrl.ItemImage.sprite = item.itemProfile.itemSprite;
        uiInvDetailCtrl.ItemQuantity.text = item.itemCount.ToString();
        uiInvDetailCtrl.ItemName.text = LocalizationManager.Localize(item.itemProfile.keyName);
        uiInvDetailCtrl.ItemDescription.text = LocalizationManager.Localize(item.itemProfile.keyDescription);
        uiInvDetailCtrl.ItemType.text = LocalizationManager.Localize("Item.Type." + item.itemProfile.itemType.ToString());
    }

    public virtual void SetEmptyUIInvDetail()
    {
        ClearButtons();
        this.itemInventory = null;

        uiInvDetailCtrl.ItemImage.sprite = null;
        uiInvDetailCtrl.ItemDescription.text = null;
        uiInvDetailCtrl.ItemName.text = null;
        uiInvDetailCtrl.ItemQuantity.text = null;
        uiInvDetailCtrl.ItemType.text = null;
    }

    public virtual void UseItem()
    {
        itemInventory.itemProfile.GetItemData<TreasureItemData>().OpenTreasure(1);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, 1);
        UIInventory.Instance.ShowItems();
    }

    public virtual void UseAllItem()
    {
        itemInventory.itemProfile.GetItemData<TreasureItemData>().OpenTreasure(itemInventory.itemCount);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, itemInventory.itemCount);
        UIInventory.Instance.ShowItems();
    }

    public virtual void SellItem()
    {
        itemInventory.itemProfile.GetItemData<SellableItemData>().SellItem(1);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, 1);
        UIInventory.Instance.ShowItems();
    }

    public virtual void SellAllItem()
    {
        itemInventory.itemProfile.GetItemData<SellableItemData>().SellItem(itemInventory.itemCount);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, itemInventory.itemCount);
        UIInventory.Instance.ShowItems();
    }

    private void ShowButtons()
    {
        ClearButtons();
        if (IsUsable())
        {
            uiInvDetailCtrl.BtnInvUse.transform.gameObject.SetActive(true);
            if (itemInventory.itemCount > 1) uiInvDetailCtrl.BtnInvUseAll.transform.gameObject.SetActive(true);
        }
        if (IsSellable())
        {
            uiInvDetailCtrl.BtnInvBuy.transform.gameObject.SetActive(true);
            if (itemInventory.itemCount > 1) uiInvDetailCtrl.BtnInvBuyAll.transform.gameObject.SetActive(true);
        }
    }

    private void ClearButtons()
    {
        uiInvDetailCtrl.BtnInvUse.transform.gameObject.SetActive(false);
        uiInvDetailCtrl.BtnInvUseAll.transform.gameObject.SetActive(false);
        uiInvDetailCtrl.BtnInvBuy.transform.gameObject.SetActive(false);
        uiInvDetailCtrl.BtnInvBuyAll.transform.gameObject.SetActive(false);
    }

    private bool IsUsable() => itemInventory.itemProfile.IsExistItemData<TreasureItemData>();

    private bool IsSellable() => itemInventory.itemProfile.IsExistItemData<SellableItemData>();
}
