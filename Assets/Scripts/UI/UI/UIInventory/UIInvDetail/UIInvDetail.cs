using Assets.SimpleLocalization;
using System.Collections.Generic;
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
        if (UIInvDetail.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInvDetail.instance = this;
    }

    protected override void OnDisable() => this.SetEmptyUIInvDetail();

    private void Update()
    {
        if (UIInventory.Instance.GetItemInventoryInCurrSlots() == null)
        {
            SetEmptyUIInvDetail();
            UIInventory.Instance.CurrSlots = -1;
            return;
        }
        SetUIInvDetail(UIInventory.Instance.GetItemInventoryInCurrSlots());
    }

    public virtual void SetUIInvDetail(ItemInventory item)
    {
        this.itemInventory = item;
        ShowButton();

        uiInvDetailCtrl.ItemImage.sprite = item.itemProfile.itemSprite;
        uiInvDetailCtrl.ItemQuantity.text = item.itemCount.ToString();
        uiInvDetailCtrl.ItemName.text = LocalizationManager.Localize(item.itemProfile.keyName);
        uiInvDetailCtrl.ItemDescription.text = LocalizationManager.Localize(item.itemProfile.keyDiscription);
        uiInvDetailCtrl.ItemType.text = LocalizationManager.Localize("Item.Type." + item.itemProfile.itemType.ToString());
    }

    public virtual void SetEmptyUIInvDetail()
    {
        HideButton();
        this.itemInventory = null;

        uiInvDetailCtrl.ItemImage.sprite = null;
        uiInvDetailCtrl.ItemDescription.text = null;
        uiInvDetailCtrl.ItemName.text = null;
        uiInvDetailCtrl.ItemQuantity.text = null;
        uiInvDetailCtrl.ItemType.text = null;
    }

    public virtual void UseItem()
    {
        Drop(itemInventory.itemProfile.listItemCanGet);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, 1);
        SetUIInvDetail(itemInventory);
        if (itemInventory.itemCount == 0) SetEmptyUIInvDetail();
        //UIInventory.Instance.ShowItems();
    }

    public virtual void UseAllItem()
    {
        for (int i = 0; i < itemInventory.itemCount; i++) Drop(itemInventory.itemProfile.listItemCanGet);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, itemInventory.itemCount);
        SetEmptyUIInvDetail();
        //UIInventory.Instance.ShowItems();
    }

    public virtual int BuyItem()
    {
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, 1);
        Wallet.Instance.AddGoldenBalance(itemInventory.itemProfile.priceToSell);
        SetUIInvDetail(itemInventory);
        int price = itemInventory.itemProfile.priceToSell;
        if (itemInventory.itemCount == 0) SetEmptyUIInvDetail();
        //UIInventory.Instance.ShowItems();
        return price;
    }

    public virtual void BuyAllItem()
    {
        Wallet.Instance.AddGoldenBalance(itemInventory.itemProfile.priceToSell * itemInventory.itemCount);
        Inventory.Instance.DeductItem(itemInventory.itemProfile.itemCode, itemInventory.itemCount);
        SetEmptyUIInvDetail();
        //UIInventory.Instance.ShowItems();
    }

    private void ShowButton()
    {
        HideButton();
        if (CanUse())
        {
            uiInvDetailCtrl.BtnInvUse.transform.gameObject.SetActive(true);
            uiInvDetailCtrl.BtnInvUseAll.transform.gameObject.SetActive(true);
        }
        if (CanBuy())
        {
            uiInvDetailCtrl.BtnInvBuy.transform.gameObject.SetActive(true);
            uiInvDetailCtrl.BtnInvBuyAll.transform.gameObject.SetActive(true);
        }
    }

    private void HideButton()
    {
        uiInvDetailCtrl.BtnInvUse.transform.gameObject.SetActive(false);
        uiInvDetailCtrl.BtnInvUseAll.transform.gameObject.SetActive(false);
        uiInvDetailCtrl.BtnInvBuy.transform.gameObject.SetActive(false);
        uiInvDetailCtrl.BtnInvBuyAll.transform.gameObject.SetActive(false);
    }

    private bool CanUse() => itemInventory.itemProfile.listItemCanGet.Count != 0;

    private bool CanBuy() => itemInventory.itemProfile.priceToSell != 0;

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return dropItems;

        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            Inventory.Instance.AddItem(itemCode, 1);
        }

        return dropItems;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        int itemDropMore;

        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate / 100000f;

            itemDropMore = Mathf.FloorToInt(itemRate);
            if (itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++) droppedItems.Add(item);
            }
        }

        return droppedItems;
    }
}
