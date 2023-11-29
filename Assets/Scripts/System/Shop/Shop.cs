using System;
using System.Collections.Generic;
using System.Linq;

public class Shop : Singleton<Shop>
{
    public string latestResetTimestamp;

    public int resetInterval;

    public List<ShopItem> listItem;

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Shop, new ShopData(this));

    public void LoadData()
    {
        ShopData shopData = SaveLoadHandler.LoadFromFile<ShopData>(FileNameData.Shop);

        if (shopData == null)
        {
            this.latestResetTimestamp = DateTime.Now.ToString();
            this.resetInterval = 0;
            ResetItem();
            return;
        }

        this.resetInterval = shopData.resetInterval;
        this.latestResetTimestamp = shopData.latestItemResetTimestamp;
        this.listItem = shopData.listItem;
    }

    protected override void Awake() => LoadData();

    public void ResetItem()
    {
        for (int i = 0; i < 10; i++)
        {
            ItemDataSO item = ItemDataSO.GetRandomSellableItemSO();
            ShopItem itemShop = new(item);
            this.listItem.Add(itemShop);
        }
        SaveData();
    }

    public void BuyItem(ShopItem item)
    {
        item.isBuy = true;
        this.SaveData();
    }
}

[Serializable]
public class ShopItem
{
    public string itemCode;
    public int quantity;
    public int price;
    public string currencyCode;
    public bool isBuy;

    public ShopItem(ItemDataSO itemDataSO)
    {
        this.itemCode = itemDataSO.itemCode.ToString();
        BuyableItemData buyableItemData = itemDataSO.datas.OfType<BuyableItemData>().FirstOrDefault();
        this.quantity = buyableItemData.quantityToBuy.GetRandomValue();
        Random random = new Random();
        int randomIndex = random.Next(0, buyableItemData.price.Count);
        ItemRangePrice priceData = buyableItemData.price[randomIndex];
        this.price = priceData.rangePrice.GetRandomValue();
        this.currencyCode = priceData.currencyCode.currencyCode.ToString();
        isBuy = false;
    }
}

[Serializable]
public class ShopData
{
    public string latestItemResetTimestamp;
    public int resetInterval = 100;
    public List<ShopItem> listItem;

    public ShopData(Shop shop)
    {
        this.latestItemResetTimestamp = shop.latestResetTimestamp;
        this.resetInterval = shop.resetInterval;
        this.listItem = shop.listItem;
    }
}